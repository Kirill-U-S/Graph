using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class o_distances
    {
        public void marshrutiki(int u, List<List<int>> arr, List<int> path, List<bool> versh, ref List<List<int>> arrpath, int N)
        {
            path = path.Append(u).ToList();  //вершина с которой мы работаем
            versh[u] = true;

            for (int v = 0; v < N; v++)
            {
                if (arr[u][v] > 0)
                {     //если между вершинами есть ребро
                    if (!versh[v])
                    {  //вершинку мы сравниваем с начальной вершиной пути(см 76 строка) и чтобы versh был не равен тру
                        marshrutiki(v, arr, path, versh, ref arrpath, N);
                    }
                    else     //используем начальную вершинку и чтобы мы не ходили по одному и тому же ребру(т е вершин задействовано больше двух)
                        arrpath = arrpath.Append(path).ToList();   //весь путь добавляем к вектору arrpath
                }
            }
            versh[u] = false;
        }
        public string o_dis(Graph g)
        {
            int N = g.A.Count();
            string output = "";
            int max = 0, min = Int32.MaxValue;


            List<List<int>> arrpath = new List<List<int>>();
            List<List<int>> arr = new List<List<int>>();
            List<int> path = new List<int>();
            List<int> ver = new List<int>();
            List<bool> versh = new List<bool>();

            #region копирование
            /*-копирование изначального массива А-*/

            /*-инициализация-*/
            for (int i = 0; i < N; i++)
            {
                List<int> b = new List<int>();
                for (int j = 0; j < N; j++)
                    b = b.Append(0).ToList();
                arr = arr.Append(b).ToList();
                arrpath = arrpath.Append(b).ToList();
            }
            /*---------------*/
            for (int i = 0; i < N; i++)
            {
                versh = versh.Append(false).ToList();
                ver = ver.Append(0).ToList();
            }

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    arr[i][j] = g.A[i][j];

            /*------------------------------------*/
            #endregion



            /*-алгоритм-*/
            for (int i = 0; i < N; i++)
                marshrutiki(i, g.A, path, versh, ref arrpath, N);
            /*----------*/

            /*-буферный массив-*/
            List<List<List<int>>> buf = new List<List<List<int>>>();

            buf.Add(arrpath);
            /*--------------------------------------*/

            #region некоторое преобразование к удобному виду
            for (int i = 0; i < buf[0].Count(); i++)
            {
                buf[0][i].Sort();
            }

            //-исключение одинаковых векторов-*/
            for (int i = 0; i < buf[0].Count(); i++)
            {
                for (int j = 0; j < buf[0].Count(); j++)
                {
                    if (i != j && buf[0][i].Count() == buf[0][j].Count())
                    {
                        bool flag = true;
                        for (int k = 0; k < buf[0][i].Count(); k++)
                            if (buf[0][i][k] != buf[0][j][k])
                                flag = false;

                        if (flag)
                            for (int k = 0; k < buf[0][j].Count(); k++)
                                buf[0][j][k] = -1;                      //если элементы повторяются
                    }
                }
            }
            // --------------------------------
            #endregion



            //исключение маршрутов, которые по размеру больше простых(которые мы и ищем)
            for (int i = 0; i < buf[0].Count(); i++)
            {
                for (int j = 0; j < buf[0].Count(); j++)
                {
                    if (buf[0][i][0] == buf[0][j][0] && buf[0][i][buf[0][i].Count() - 1] == buf[0][j][buf[0][j].Count() - 1] && i != j)
                    {
                        if (buf[0][i].Count() < buf[0][j].Count())
                            for (int k = 0; k < buf[0][j].Count(); k++)
                                buf[0][j][k] = -1;
                        else
                            for (int k = 0; k < buf[0][i].Count(); k++)
                                buf[0][i][k] = -1;
                    }
                }
            }
            //эксцентриситет
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < buf[0].Count(); j++)
                {
                    if (buf[0][j][0] == i || buf[0][j][buf[0][j].Count() - 1] == i)
                        if (ver[i] < buf[0][j].Count())
                            ver[i] = buf[0][j].Count() - 1;
                }
            }

            /*-вывод минимальных расстояний*/
            //for (int i = 0; i < buf[0].Count(); i++)
            //{
            //    for (int j = 0; j < buf[0][i].Count(); j++)
            //        if (buf[0][i][j] == -1)
            //            break;
            //        else
            //        {
            //            output += buf[0][i][j] + " ";
            //        }
            //    if (buf[0][i][0] != -1)
            //        output += "\n";
            //}

            for (int i = 0; i < N; i++)
            {
                output += "for " + i + ": " + ver[i] + "\n";
                if (ver[i] > max)
                    max = ver[i];
                else if (ver[i] < min)
                    min = ver[i];
            }
            output += "Center: ";
            for (int i = 0; i < N; i++)
            {
                if (ver[i] == min)
                    output += i + " ";
            }
            output += "\nDiameter: " + max;
            output += "\nRadius: " + min;
            return output;
        }
    }
}
