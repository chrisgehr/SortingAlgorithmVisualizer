using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm_Visualizer
{
    public partial class MainForm : Form
    {
        Model model;
        Graphics gObject;
        Thread thread1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void shuffle_Click(object sender, EventArgs e)
        {
            if(thread1 != null)
            {
                thread1.Abort();
            }
            
            model.integers = model.Shuffle(model.integers);
            model.DrawShuffledList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gObject = canvas.CreateGraphics();
            model = new Model(gObject, canvas);
            AlgorithmChoice.SelectedIndex = 0;
        }

        private void sort_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
            }

            thread1 = new Thread(this.ThreadFunction);
            thread1.Start(AlgorithmChoice.Text);

        }

        private void ThreadFunction(Object obj)
        {
            switch((string) obj)
            {
                case "Bubble Sort": model.BubbleSort(model.integers);
                    break;
                case "Quick Sort": model.QuickSort(model.integers, 0, model.integers.Count - 1);
                    break;
                case "Insertion Sort":
                    model.InsertionSort(model.integers);
                    break;
                case "Heap Sort":
                    model.HeapSort(model.integers);
                    break;
                case "Merge Sort":
                    model.MergeSort(model.integers, 0, model.integers.Count - 1);
                    break;
                default:
                    break;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
            }
        }
    }
}
