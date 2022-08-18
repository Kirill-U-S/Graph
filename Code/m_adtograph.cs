using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class m_adtograph
    {
        //вывод таблицы смежности для дополнения к графу
        public string m_ad(Graph g)
        {
            int N = g.A.Count;
            string output = "";
            List<List<int>> dop = new List<List<int>>();
            List<List<int>> smezh = new List<List<int>>();
            #region инициализация
            for (int i = 0; i < N; i++)
            {
                List<int> buf = new List<int>();
                for (int j = 0; j < N; j++)
                    buf = buf.Append(0).ToList();

                dop = dop.Append(buf).ToList();
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
                for (int j = 0; j < N; j++)
                {
                    if (smezh[i][j] == 0)
                        dop[i][j] = 1;
                    else
                        dop[i][j] = 0;
                    dop[i][i] = 0;
                    output += dop[i][j] + " ";
                }
                output += "\n";
            }
            return output;
        }

    }
}
