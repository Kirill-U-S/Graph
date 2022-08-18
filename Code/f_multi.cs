using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_multi
    {
        //является ли мультиграфом
        public string f_mul(Graph g)
        {
            int N = g.A.Count();
            List<List<int>> smezh = new List<List<int>>();
            bool multi = false;
            bool gd = true;

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
                    if (smezh[j][j] != 0) //на главной диагонали(гг) должны быть нули 
                        gd = false;
                    if (i != j && smezh[i][j] > 1)   //хотя бы одно ребро (не элемент гг) должно быть кратным(элемент должен быть равен 2 или более)
                        multi = true;
                }
            }
            if (multi && gd)
                return "multigraph";
            else
                return "not multi";
        }

    }
}
