using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class a_prima
    {
        public string method(Graph g)
        {
            int N = g.A.Count;
            string output = "";
            List<bool> versh = new List<bool>();
            
            var buf = Enumerable.Repeat(0, N).ToList();
            var arr = Enumerable.Repeat(buf, N).ToList();

            /*копирование изначального массива А*/
            buf = Enumerable.Repeat(0, N).ToList();
            var smezh = Enumerable.Repeat(buf, N).ToList();
            buf.Clear();
            /*----------------------------------*/

            //массивы arr and versh должны быть полностью в нулях
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    smezh[i][j] = g.A[i][j];
                    arr[i][j] = 0;
                }
                versh[i] = false;
            }
            versh[0] = true;

            int y = 0, x = 0, sum = 0, k = 0;
            #region сам алгоритм
            while (k++ < N - 1)
            {
                int minn = int.MaxValue;
                for (int i = 0; i < N; i++)
                    if (!versh[i])
                        arr[x][i] = smezh[x][i]; //присваивание строки

                arr[y][x] = 0;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if ((arr[i][j] < minn) && (arr[i][j] > 0) && !versh[j])
                        {
                            minn = arr[i][j];
                            y = i; // last
                            x = j; // найденная вершина
                        }
                    }
                }
                if (arr[y][x] > 0)
                    versh[x] = true;
                else
                    versh[x] = false;

                if (versh[x])
                    sum++;
                output += $"Step {k}: edge {y} - {x}, weight {versh[x]}. sum: {sum}\n";
            }
            #endregion

            return output;
        }
    }
}
