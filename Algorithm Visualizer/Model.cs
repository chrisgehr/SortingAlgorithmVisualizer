using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    class Model
    {
        public List<int> integers;
        public Graphics graphics;
        public PictureBox canvas;

        /// <summary>
        /// Simple constructor initializing the List.
        /// </summary>
        public Model(Graphics graphics, PictureBox canvas)
        {
            this.graphics = graphics;
            this.canvas = canvas;
            integers = new List<int>();

            for(int i = 1; i <= 80; i++)
            {
                integers.Add(i);
            }
        }


        /// <summary>
        /// Fisher-Yates styled shuffle algorithm to avoid bias
        /// </summary>
        /// <param name="list">The array to be shuffled.</param>
        /// <returns></returns>
        public List<int> Shuffle(List<int> list)
        {
            Random rand = new Random();

            for(int i = 0; i < list.Count; i++)
            {
                int k = rand.Next(0, i);
                int temp = list[k];
                list[k] = list[i];
                list[i] = temp;
            }
            return list;
        }


        /// <summary>
        /// Simple bubble sort with end condition, when inner loop does not swap.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        public void BubbleSort(List<int> list)
        {
            bool swapped;
            for (int i = 0; i < list.Count - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {

                        SwapAndDraw(list, j, j + 1);
                        swapped = true;
                    }
                }
                if (swapped == false)
                    break;
            }
        }


        /// <summary>
        /// Quick sort algorithm, calling partition function + recursion.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        /// <param name="start">Startpoint.</param>
        /// <param name="end">Endpoint.</param>
        public void QuickSort(List<int> list, int start, int end)
        {
            if(start < end)
            {
                int partitionIndex = Partition(list, start, end);

                QuickSort(list, start, partitionIndex - 1);
                QuickSort(list, partitionIndex + 1, end);
            }
        }


        /// <summary>
        /// Partition function of quick sort.
        /// Orders the list based on a pivot element.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        /// <param name="start">Startpoint.</param>
        /// <param name="end">Endpoint.</param>
        /// <returns></returns>
        public int Partition(List<int> list, int start, int end)
        {
            // Selecting pivot.
            int pivot = list[end];

            int pivotIndex = start;

            // Reorder.
            for (int i = start; i < end; i++)
            {
                if (list[i] < pivot)
                {
                    SwapAndDraw(list, pivotIndex, i);
                    pivotIndex++;
                }
            }

            SwapAndDraw(list, pivotIndex, end);

            return pivotIndex;
        }


        /// <summary>
        /// Insertion sort algorithm.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        public void InsertionSort(List<int> list)
        {
            for(int i = 1; i < list.Count; i++)
            {
                int j = i;

                while(j > 0)
                {
                    if(list[j - 1] > list[j])
                    {
                        SwapAndDraw(list, j - 1, j);
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }


        /// <summary>
        /// HeapSort Sorting Algorithm. Uses heapify.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        public void HeapSort(List<int> list)
        {
            int length = list.Count;

            // Build up the heap.
            for(int i = length / 2 - 1; i >= 0; i--)
            {
                heapify(list, length, i);
            }

            // The top element of the heap is the biggest. This it gets swapped with the last position and ignored in the later steps.
            for(int i = length - 1; i > 0; i--)
            {
                SwapAndDraw(list, 0, i);

                // Heapify applied to the reduced heap.
                heapify(list, i, 0);
            }

        }


        /// <summary>
        /// Creates the max heap needed for heap sorting.
        /// </summary>
        /// <param name="list">The array for the heap sort.</param>
        /// <param name="length">The length of the remaining heap.</param>
        /// <param name="i">Root of the heap.</param>
        public void heapify(List<int> list, int length, int i)
        {
            // Assume the root is the biggest element.
            int biggest = i;

            // Logic to simulate a binary tree in an array.
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if(left < length && list[left] > list[biggest])
            {
                biggest = left;
            }

            if(right < length && list[right] > list[biggest])
            {
                biggest = right;
            }

            if(biggest != i)
            {
                SwapAndDrawHeapify(list, i, biggest);
                
                // Also change subtree.
                heapify(list, length, biggest);
            }
        }


        /// <summary>
        /// The Merge function of the MergeSort Algorithm. Merges the smaller arrays.
        /// The smaller arrays go from left to middle and from middle to right.
        /// </summary>
        /// <param name="list">The array.</param>
        /// <param name="left">Implying position of smaller array.</param>
        /// <param name="middle">Middle dividing the 2 arrays.</param>
        /// <param name="right">End of right half.</param>
        void Merge(List<int> list, int left, int middle, int right)
        {
            // Calculate the size of the temporary arrays.
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Create temporary arrays.
            List<int> L = new List<int>(n1);
            List<int> R = new List<int>(n2);
            int i, j;

            // Copy data to temporary arrays.
            for (i = 0; i < n1; i++)
                L.Add(list[left + i]);
            for (j = 0; j < n2; j++)
                R.Add(list[middle + 1 + j]);

            // Initial indexes.
            i = 0;
            j = 0;

            // Initial index of merged array.
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    ChangeAndDraw(list, k, L[i]);
                    i++;
                }
                else
                {
                    ChangeAndDraw(list, k, R[j]);
                    j++;
                }
                k++;
            }

            // Copy remaining elements.
            while (i < n1)
            {
                ChangeAndDraw(list, k, L[i]);
                i++;
                k++;
            }

            // Copy remaining elements.
            while (j < n2)
            {
                ChangeAndDraw(list, k, R[j]);
                j++;
                k++;
            }
        }


        /// <summary>
        /// The main MergeSort function that calls itself recursively and merges.
        /// </summary>
        /// <param name="list">The array to be sorted.</param>
        /// <param name="left">Beginning of array.</param>
        /// <param name="right">End of array.</param>
        public void MergeSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                // Find the middle.
                int middle = (left + right) / 2;

                // Keep on sorting in smaller arrays.
                MergeSort(list, left, middle);
                MergeSort(list, middle + 1, right);

                // Merge the sorted halves.
                Merge(list, left, middle, right);
            }
        }


        /// <summary>
        /// Draws the shuffled list.
        /// </summary>
        public void DrawShuffledList()
        {
            // Clear canvas before visualizing.
            graphics.Clear(canvas.BackColor);

            // Fill all array elements.
            for (int i = 0; i < integers.Count; i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), i * 10, 0 + canvas.Height - (integers[i] * 4), 10, integers[i] * 4);
            }

        }


        /// <summary>
        /// Executes the swapping + added swap logic.
        /// </summary>
        /// <param name="list">The array that needs swap function.</param>
        /// <param name="a">First element to be swapped.</param>
        /// <param name="b">Second element to be swapped.</param>
        public void SwapAndDraw(List<int> list, int a, int b)
        {
            // Override the current elements or their length stays in the canvas.
            graphics.FillRectangle(new SolidBrush(Color.Lavender), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Lavender), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            int temp = list[a];
            
            list[a] = list[b];

            list[b] = temp;

            graphics.FillRectangle(new SolidBrush(Color.Red), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Red), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            // Sleep for visualization.
            Thread.Sleep(1);

            // After waiting paint them black again.
            graphics.FillRectangle(new SolidBrush(Color.Black), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Black), b * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);
        }


        /// <summary>
        /// An extra swap function for heapify, to use different colors.
        /// </summary>
        /// <param name="list">The array that needs swap function.</param>
        /// <param name="a">First element to be swapped.</param>
        /// <param name="b">Second element to be swapped.</param>
        public void SwapAndDrawHeapify(List<int> list, int a, int b)
        {
            // Override the current elements or their length stays in the canvas.
            graphics.FillRectangle(new SolidBrush(Color.Lavender), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Lavender), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            int temp = list[a];

            list[a] = list[b];

            list[b] = temp;

            graphics.FillRectangle(new SolidBrush(Color.Blue), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Blue), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            // Sleep for visualization.
            Thread.Sleep(10);

            // After waiting paint them black again.
            graphics.FillRectangle(new SolidBrush(Color.Black), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Black), b * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);
        }


        /// <summary>
        /// An extra change function that also draws the change.
        /// </summary>
        /// <param name="list">The list in which the change is to happen.</param>
        /// <param name="index">The index of the element to be changed.</param>
        /// <param name="value">The new value.</param>
        public void ChangeAndDraw(List<int> list, int index, int value)
        {
            graphics.FillRectangle(new SolidBrush(Color.Lavender), index * 10, 0 + canvas.Height - (list[index] * 4), 10, list[index] * 4);

            list[index] = value;

            graphics.FillRectangle(new SolidBrush(Color.Red), index * 10, 0 + canvas.Height - (list[index] * 4), 10, list[index] * 4);

            Thread.Sleep(10);

            graphics.FillRectangle(new SolidBrush(Color.Black), index * 10, 0 + canvas.Height - (list[index] * 4), 10, list[index] * 4);
        }
    }
}
