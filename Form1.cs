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
        void Print(Graph g, string zn)
        {
            int N = g.A.Count;
            string str = "";

            if (zn == "A")
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        str += g.A[i][j] + " ";
                    }
                    str += "\n";
                }
            }
            else if (zn == "E")
            {
                for (int i = 0; i < N; i++)
                {
                    str += $"ребро {i}, м/у {g.E[i][0]} - {g.E[i][1]}, значение {g.A[int.Parse(g.E[i][0].ToString())][int.Parse(g.E[i][1].ToString())]}\n";
                }
            }

            cmd.Text = str;
        }
        void Example()
        {
            var A = new List<List<int>>();
            //string a = "0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0";
            //int N = 5;
            string a = "0 1 1 0  1 0 1 1  1 1 0 1  0 1 1 0";//пример для дейкстры
            int N = 4;
            //----------
            Graph g = new Graph(N, a);
            Print(g, "E");
            cmd.Text = g.a_cycles();
            //----------

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Example();
        }
    }
}
