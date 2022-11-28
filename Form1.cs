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
        Graph g;
        public int Selected { get; set; }
        public int Transform { get; set; }
        List<TextBox> Arr;
        public Form1()
        {
            InitializeComponent();
            Selected = 0;
            Transform = 0;
            cmd.Text = "";
            L_ArrayOfA.Text = "";
            Arr = new List<TextBox>();
        }
        /// <summary>
        /// Выводит в текстовом виде массив графа
        /// </summary>
        /// <param name="g">Граф</param>
        /// <param name="zn">Массив, который нужно вывести</param>
        void Print(Graph g, string zn)
        {
            int N = g.A.Count;
            string str = "";

            if (zn == "A")
            {
                for (int i = 0; i < N; i++)
                {
                    str += "|";
                    for (int j = 0; j < N; j++)
                    {
                        str += $" {g.A[i][j]}{string.Concat(Enumerable.Range(0, (3 - g.A[i][j].ToString().Length)).Select(x => " "))}|";
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

            L_ArrayOfA.Text = str;
        }
        /// <summary>
        /// Метод выводит в текстовом виде матрицу выбранного графа
        /// </summary>
        /// <param name="sel">Выбранный граф</param>
        void Example_Out(int sel)
        {
            #region примеры
            string a = "";
            int N = 0;
            switch (sel)
            {
                case 1:
                    //случайный граф
                    a = " 0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0 ";
                    N = 5;
                    break;
                case 2:
                    //пример для дейкстры
                    a = " 0 1 1 0  1 0 1 1  1 1 0 1  0 1 1 0 ";
                    N = 4;
                    break;
                case 3:
                    //пример для краскала
                    N = 10;
                    a = " 0 10 0 0 20 0 0 15 0 0  10 0 5 0 0 0 0 2 8 9  0 5 0 16 0 0 0 0 4 0  0 0 16 0 28 25 0 0 11 9  20 0 0 28 0 15 0 0 0 0  0 0 0 25 15 0 10 0 7 5  0 0 0 0 0 10 0 11 0 3  15 2 0 0 0 0 11 0 4 14  0 8 4 11 0 7 0 4 0 0  0 9 0 9 0 5 3 14 0 0 ";
                    break;
                case 4:
                    //'случайный' граф
                    a = " 0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0 ";
                    N = 5;
                    break;
                default:
                    //'случайный' граф
                    a = " 0 1 0 1 0  1 0 1 0 0  0 1 0 1 1  1 0 1 0 1  0 0 1 1 0 ";
                    N = 5;
                    break;
            }
            #endregion
            g = new Graph(N, a);
            Print(g, "A");

            //-Некоторые проверенные алгоритмы-
            //cmd.Text += g.a_dijkstra();   //проверен на многих/выдает логичные данные, но не регулируемые (как и с циклами)
            //cmd.Text += g.a_kraskala();   //проверен на многих примерах
            //cmd.Text += g.f_multi();      //проверен на одном примере
            //cmd.Text += g.f_connect();    //на данный момент не проверен - причина описана в комменте в самом классе
            //cmd.Text += g.f_psevdo();     //проверен на одном примере
            //cmd.Text += g.f_regular();    //проверен на одном примере
            //---------------------------------
        }
        /// <summary>
        /// Метод осуществляет преобразование графа соответственно параметру trans - порядок установлен в соответствии с порядком файлов алгоритмов
        /// </summary>
        /// <param name="trans">параметр позволяющий указать преобразование</param>
        void Transform_Out(int trans)
        {
            cmd.Text = "";
            //выборка преобразования графа соответствует порядку файлов алгоритмов
            switch (trans)
            {
                case 1:
                    //пока что не работает
                    //cmd.Text += g.a_cycles();
                    break;
                case 2:
                    cmd.Text += g.a_dijkstra();     //проверен на многих/выдает логичные данные, но не регулируемые (как и с циклами)
                    break;
                case 3:
                    cmd.Text += g.a_kraskala();     //проверен на многих примерах
                    break;
                case 4:
                    cmd.Text += g.a_prima();        //
                    break;
                case 5:
                    cmd.Text += g.f_complete();     //
                    break;
                case 6:
                    cmd.Text += g.f_connect();      //
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Создает матрицу из текстбоксов посередине экрана
        /// </summary>
        /// <param name="n">размер</param>
        void Render(int n)// size
        {
            Delete();

            int X = (this.Size.Width / 2) - 15, Y = this.Size.Height / 2 - 11;//изначальная позиция
            int l, x, y;
            int kx = 26, ky = 22;//коэффициенты сдвига 10 6
            int TextBox_X = 24, TextBox_Y = 16;// 6
            //сдвиг на 0 уровень
            if ((n % 2) == 0)
            {
                x = Convert.ToInt32(Convert.ToDouble(X) - 1.0 / 2.0 * Convert.ToDouble(kx));
                y = Convert.ToInt32(Convert.ToDouble(Y) - 1.0 / 2.0 * Convert.ToDouble(ky));
                l = -1;//количество шагов для одной стороны
                for (int k = 1; k <= n / 2; k++)
                {
                    l += 2;//шаг увеличивается на два (прибавление с каждой стороны)

                    //внутренний цикл отвечает за каждый отдельный шаг
                    for (int i = 1; i <= 4 * l; i++)
                    {
                        Arr.Add(new TextBox()
                        {
                            Text = "0",
                            Location = new Point(x, y),
                            Size = new Size(TextBox_X, TextBox_Y)
                        });

                        this.Controls.Add(Arr[Arr.Count - 1]);
                        if (i <= l || (2 * l < i && i <= 3 * l))//if отлавливает моменты когда не должен меняться x или y
                        {                                       //внутренний if отвечает за направление обхода
                            //x - не меняется
                            if (i <= l)
                                y += ky;
                            else
                                y -= ky;
                        }
                        else if ((i > l && i <= 2 * l) || (i > 3 * l && i <= 4 * l))
                        {
                            //y - не меняется
                            if (i <= 2 * l && i >= l)
                                x += kx;
                            else
                                x -= kx;
                        }
                    }

                    //сдвиг на новый уровень
                    x -= kx;
                    y -= ky;
                }
            }
            else
            {
                x = X - kx;
                y = Y - ky;
                l = 0;//количество шагов для одной стороны
                Arr.Add(new TextBox() { 
                    Text = "0",
                    Location = new Point(X, Y),
                    Size = new Size(TextBox_X, TextBox_Y)
                });
                this.Controls.Add(Arr[0]);
                for (int k = 1; k <= (n - 1) / 2; k++)
                {
                    l += 2;//шаг увеличивается на два (прибавление с каждой стороны)
                           //внутренний цикл отвечает за каждый отдельный шаг
                    for (int i = 1; i <= 4 * l; i++)
                    {
                        Arr.Add(new TextBox()
                        {
                            Text = "0",
                            Location = new Point(x, y),
                            Size = new Size(TextBox_X, TextBox_Y)
                        });
                        this.Controls.Add(Arr[Arr.Count - 1]);
                        if (i <= l || (2 * l < i && i <= 3 * l))//if отлавливает моменты когда не должен меняться x или y
                        {                                       //внутренний if отвечает за направление обхода
                            //x - не меняется
                            if (i <= l)
                                y += ky;
                            else
                                y -= ky;
                        }
                        else if ((i > l && i <= 2 * l) || (i > 3 * l && i <= 4 * l))
                        {
                            //y - не меняется
                            if (i <= 2 * l && i >= l)
                                x += kx;
                            else
                                x -= kx;
                        }
                    }

                    //сдвиг на новый уровень
                    x -= kx;
                    y -= ky;
                }
            }
        }
        /// <summary>
        /// данный метод идет в паре с Render и удаляет текстбоксы созданные в Render
        /// </summary>
        void Delete()
        {
            for (int i = 0; i < Arr.Count; i++)
            {
                //Arr[i].Controls.Remove(Arr[i]);
                
                Arr[i].Dispose();
            }
            Arr.Clear();
            //Arr = new List<TextBox>();
        }
        private void B_Out_Click(object sender, EventArgs e)
        {
            Example_Out(Selected);
            Transform_Out(Transform);
        }
        private void B_Transform_Click(object sender, EventArgs e)
        {
            Transform_Out(Transform);
        }

        private void CB_Example_SelectedIndexChanged(object sender, EventArgs e)
        {
            Selected = CB_Example.SelectedIndex + 1;
        }
        private void CB_Transform_SelectedIndexChanged(object sender, EventArgs e)
        {
            Transform = CB_Transform.SelectedIndex + 1;
        }

        private void B_SetScale_Click(object sender, EventArgs e)
        {
            if(int.TryParse(CB_Scale.Text, out int n))
                Render(n);
        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
