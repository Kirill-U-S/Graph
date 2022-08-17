using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_complete_graph
    {
        public string complete(Graph g)
        {
            int N = g.A.Count;
            string output = "";
            bool ed = true;
            for (int i = 0; i < N, !g.A[j][j]; i++) //!g.A[j][j] - не хочет работать((
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j)                 //всё кроме главной диагонали должно быть в единицах,
                    {                           //поэтому смотрим на все элементы кроме диагональных
                        if (g.A[i][j] != 1)
                            ed = false;
                    }
                }
            }
            if (ed)
                output += "complete";   //если для орграфа, то strongly connected
            else
                output += "incomplete";
            return output;
        }
    }
}