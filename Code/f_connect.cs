using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //TODO: данный отрезок кода требует m_reachability
    class f_connect
    {
        //связный ли граф
        public string f_con(Graph g)
        {
            int N = g.A.Count();
            List<List<int>> matrix = new List<List<int>>();
            Graph a = new Graph(N);
            a = g;

            /*int** matrix = reachability_m(a);*/  //TODO: переделать позже построение матрицы достижимости
            bool flag = true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix[i][j] != 1)    //все элементы данной матрицы должны быть единицами по опр связного графа
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag)
                return "connected";
            else
                return "disconnected";
        }
    }
}
