using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Print(int N, List<List<int>> A)
        {
            string str = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    str += A[i][j] + " ";
                }
                str += "\n";
            }

            cmd.Text = str;
        }
        void Example()
        {
            var N = 5;
            var A = new List<List<int>>();
            string a = "0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0";
            //string a = "0 1 1 0  1 0 1 1  1 1 0 1  0 1 1 0";//пример для дейкстры
            //----------
            Graph g = new Graph(N, a);

            cmd.Text = g.a_cycles();
            //----------

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Example();
        }
    }
}
