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
            #region примеры
            //'случайный' граф
            //string a = " 0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0 ";
            //int N = 5;
            //пример для дейкстры
            //string a = " 0 1 1 0  1 0 1 1  1 1 0 1  0 1 1 0 ";
            //int N = 4;
            //пример для краскала
            int N = 10;
            string a = " 0 10 0 0 20 0 0 15 0 0  10 0 5 0 0 0 0 2 8 9  0 5 0 16 0 0 0 0 4 0  0 0 16 0 28 25 0 0 11 9  20 0 0 28 0 15 0 0 0 0  0 0 0 25 15 0 10 0 7 5  0 0 0 0 0 10 0 11 0 3  15 2 0 0 0 0 11 0 4 14  0 8 4 11 0 7 0 4 0 0  0 9 0 9 0 5 3 14 0 0 ";
            #endregion
            //----------
            Graph g = new Graph(N, a);
            Print(g, "A");

            cmd.Text += g.a_cycles();
            cmd.Text += "\nthe end";
            //cmd.Text += g.a_dijkstra();   //проверен на многих/выдает залупу-пупу - логичную, но не регулируемую (как и с циклами)
            //cmd.Text += g.a_kraskala();   //проверен на многих примерах
            //cmd.Text += g.f_multi();      //проверен на одном примере
            //cmd.Text += g.f_connect();    //на данный момент не проверен - причина описана в комменте в самом классе
            //cmd.Text += g.f_psevdo();     //проверен на одном примере
            //cmd.Text += g.f_regular();    //проверен на одном примере
            //----------
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Example();
        }
    }
}
