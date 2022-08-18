using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_psevdo
    {
        public string f_psev(Graph g)
        {
            int N = g.A.Count();
            List<List<int>> smezh = new List<List<int>>();
            bool multi = false;
            bool gd = false;

            #region инициализация
            for (int i = 0; i < N; i++)
            {
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
                for (int j = 0; j < N; j++)
                {
                    if (i != j && smezh[i][j] > 1) //проверка на существование в графе кратных ребер
                        multi = true;
                    else if (i == j && smezh[i][j] > 0) //проверка на существование в графе петель
                        gd = true;
                    else continue;
                }
            }
            if (multi && gd)
                return "psevdograph";
            else
                return "not psevdograph";
        }
    }
}
