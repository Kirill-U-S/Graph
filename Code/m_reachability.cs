using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class m_reachability
    {
        //построение таблицы достижимости
        // Ремарка: чтобы использовать данный алгоритм в рамках другого алгоритма(f_connect), в том самом другом алгоритме нужно перевести с sting в list<<>>
        // Либо Дописать здесь по аналогии с dfs_cut -- m_reach_cut
        public string m_reach(Graph g)
        {
            int N = g.A.Count;
            string output = "";
            List<List<int>> reachability = new List<List<int>>();
            List<List<int>> smezh = new List<List<int>>();
            #region инициализация
            for (int i = 0; i < N; i++)
            {
                List<int> buf = new List<int>();
                for (int j = 0; j < N; j++)
                    buf = buf.Append(0).ToList();

                reachability = reachability.Append(buf).ToList();
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
                    if (i == j)
                        reachability[i][i] = 1;         //элементы на главной диагонали необходимо сделать единицами
                    else if (smezh[i][j] > 0)           //все единицы из таблицы смежности нужно добавить в новую матрицу
                        reachability[i][j] = reachability[j][i] = 1;
                    else
                    {
                        //поиск маршрута
                        int k = i;
                        for (int m = 0; m < N; m++)
                        {
                            if (smezh[k][m] > 0 && smezh[m][j] > 0)
                                reachability[i][j] = reachability[j][i] = 1;
                            else if (smezh[k][m] > 0)
                                k = m;
                        }
                    }
                    output += reachability[i][j] + " ";
                }
                output += "\n";
            }
            return output;
        }

    }
}
