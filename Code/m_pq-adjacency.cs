using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class m_pq_adjacency
    {
        public string pq_pp(Graph g)
        {
            int N = g.A.Count();
            int rebrs = g.D[0].Count();

            string output = "";
            List<List<int>> pq = new List<List<int>>();
            List<List<int>> smezh = new List<List<int>>();
            #region инициализация
            for (int i = 0; i < N; i++)
            {
                List<int> buf = new List<int>();
                for (int j = 0; j < N; j++)
                    buf = buf.Append(0).ToList();

                smezh = smezh.Append(buf).ToList();
            }
            for (int i = 0; i < N; i++)
            {
                List<int> buf = new List<int>();
                for (int j = 0; j < rebrs; j++)
                    buf = buf.Append(0).ToList();

                pq = pq.Append(buf).ToList();
            }
            #endregion
            #region копирование
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    smezh[i][j] = g.A[i][j];
                for (int j = 0; j < rebrs; j++)
                    pq[i][j] = g.D[i][j];
            }
            #endregion
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < rebrs; j++)
                {
                    if (pq[i][j] == 1)
                    {
                        int x = i;
                        int y = j;
                        for (int z = x + 1; z < N; z++)
                            if (pq[z][y] == 1)
                                smezh[x][z] = smezh[z][x] = 1;
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    output += smezh[i][j] + " ";
                output += "\n";
            }
            return output;
        }

    }
}
//void Init(string a, int N, int rebrs, List<List<int>> D)
//{
//    //    a = a.Replace(" ", ""); //для смежности
//    //    for (int i = 0; i < N; i++)
//    //    {
//    //        var buf = Enumerable.Repeat(0, N).ToList();
//    //        for (int j = 0; j < N; j++)
//    //        {
//    //            buf[j] = int.Parse(a[i * N + j].ToString());
//    //        }
//    //        A.Add(buf);
//    //    }
//    a = a.Replace(" ", ""); //для инцидентности
//    for (int i = 0; i < N; i++)
//    {
//        List<int> buf = new List<int>();
//        for (int j = 0; j < rebrs; j++)
//            buf = buf.Append(int.Parse(a[i * rebrs + j].ToString())).ToList();

//        D.Add(buf);
//    }

//}
//void Init2(string a, int N, ref List<List<int>> A)
//{
//    for (int i = 0; i < N; i++)
//    {
//        var buf = Enumerable.Repeat(0, N).ToList();
//        for (int j = 0; j < N; j++)
//        {
//            buf[j] = 0;
//        }
//        A.Add(buf);
//    }
//}
//public Graph(int V, string str)
//{
//    str = str.Replace(" ", "");
//    int ed = 0;

//    int rebrs = str.Length / V;
//    for (int i = 0; i < V; i++)
//        if (int.Parse(str[i].ToString()) != 0)
//            ed++;
//    D = new List<List<int>>();
//    A = new List<List<int>>();
//    EE = new List<string>();
//    for (int i = 0; i < V; i++)
//    {
//        List<int> buf = new List<int>();
//        for (int k = 0; k < V; k++)
//            buf.Add(0);

//        List<int> buff = new List<int>();
//        for (int k = 0; k < rebrs; k++)
//            buff.Add(0);

//        for (int j = 0; j < rebrs; j++)
//            buff[j] = int.Parse(str[i * V + j].ToString());

//        for (int j = 0; j < V; j++)
//        {
//            buf[j] = 0;
//        }
//        D.Add(buff);
//        A.Add(buf);
//    }