using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class o_degree
    {
        //просмотрено
        //min max mid степени
        public string o_deg(Graph g)
        {
            int N = g.A.Count;
            string output = "";
            int max = 0, min = N, Sum = 0;
            List<int> deg = new List<int>();
            List<List<int>> smezh = new List<List<int>>();
            #region инициализация
            for (int i = 0; i < N; i++)
            {
                deg = deg.Append(0).ToList();
                List<int> buf = new List<int>();
                for (int j = 0; j < N; j++)
                    buf = buf.Append(0).ToList();

                smezh = smezh.Append(buf).ToList();
            }
            #endregion
            #region копирование
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    smezh[i][j] = g.A[i][j];
            #endregion
            for (int i = 0; i < N; i++)
            {
                int sum = 0;
                for (int j = 0; j < N; j++)
                    sum += smezh[i][j];
                deg[i] = sum;
                if (deg[i] > max)
                    max = deg[i];
                if (deg[i] < min)
                    min = deg[i];
                Sum += deg[i];
            }
            output += $"max deg: {max}\nmin deg: {min}\nsred deg: {Sum / Convert.ToDouble(N)}";
            return output;
        }

    }
}
