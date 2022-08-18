using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_complete
    {
        //полный или сильносвязный граф(между любыми двумя вершинами должно быть одно ребро)
        public string f_comp(Graph g)
        {
            int N = g.A.Count();
            bool ed = true;

            List<List<int>> smezh = new List<List<int>>();
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
                    if(smezh[i][j] != 0)
                    {

                    }
                    else if (i != j)                 //всё кроме главной диагонали должно быть в единицах,
                    {                           //поэтому смотрим на все элементы кроме диагональных
                        if (smezh[i][j] != 1)
                            ed = false;
                    }
                }
            }

            if (ed)
                return "complete";   //если для орграфа, то strongly connected
            else
                return "incomplete";
        }

    }
}
