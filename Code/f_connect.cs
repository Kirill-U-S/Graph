using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_connect
    {
        //связный ли граф
        List<int> intermediate_for_reachability_f_connect(string m_reachi, int N)
        {
            List<int> matrix = new List<int>();
            m_reachi = m_reachi.Replace(" ", "");
            m_reachi = m_reachi.Replace("\n", "");
            int ed = 0;

            for (int i = 0; i < N; i++)
                if (int.Parse(m_reachi[i].ToString()) != 0)
                    ed++;

            for (int i = 0; i < N; i++)
            {
                var buf = Enumerable.Repeat(0, N).ToList();
                for (int j = 0; j < N; j++)
                {
                    buf[j] = int.Parse(m_reachi[i * N + j].ToString());
                    matrix.Add(buf[j]);
                }
            }
            return matrix;
        }
        public string f_con(Graph g)
        {
            int N = g.A.Count();
            string output = "";
            List<int> matrix = new List<int>();

            m_reachability rea = new m_reachability();
            matrix = intermediate_for_reachability_f_connect(rea.m_reach(g), N);

            bool flag = true;
            for (int i = 0; i < N; i++)
            {
                if (matrix[i] != 1)    //все элементы данной матрицы должны быть единицами по опр связного графа
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
                output = "connected";
            else
                output = "disconnected";
            return output;
        }
    }
}
