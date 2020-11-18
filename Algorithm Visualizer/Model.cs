﻿using System;
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
        /// <param name="list"></param>
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
        /// <param name="list"></param>
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
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void QuickSort(List<int> array, int start, int end)
        {
            if(start < end)
            {
                int partitionIndex = Partition(array, start, end);

                QuickSort(array, start, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, end);
            }
        }

        /// <summary>
        /// Partition function of quick sort.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int Partition(List<int> array, int start, int end)
        {
            //Selecting pivot.
            int pivot = array[end];

            int pivotIndex = start;

            //Reorder.
            for (int i = start; i < end; i++)
            {
                if (array[i] < pivot)
                {
                    SwapAndDraw(array, pivotIndex, i);
                    pivotIndex++;
                }
            }

            SwapAndDraw(array, pivotIndex, end);

            return pivotIndex;
        }

        /// <summary>
        /// Insertion sort algorithm.
        /// </summary>
        /// <param name="list"></param>
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
        /// <param name="list"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void SwapAndDraw(List<int> list, int a, int b)
        {
            // Override the current elements or their length stays in the canvas.
            graphics.FillRectangle(new SolidBrush(Color.White), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.White), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            int temp = list[a];
            
            list[a] = list[b];
            graphics.FillRectangle(new SolidBrush(Color.Red), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            
            list[b] = temp;
            graphics.FillRectangle(new SolidBrush(Color.Red), (b) * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);

            // Sleep for visualization.
            Thread.Sleep(1);

            // After waiting paint them black again.
            graphics.FillRectangle(new SolidBrush(Color.Black), a * 10, 0 + canvas.Height - (list[a] * 4), 10, list[a] * 4);
            graphics.FillRectangle(new SolidBrush(Color.Black), b * 10, 0 + canvas.Height - (list[b] * 4), 10, list[b] * 4);
        }
    }
}