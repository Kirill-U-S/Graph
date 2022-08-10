using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class a_kraskala
    {
        public string a_kraskal(Graph g)
        {
            int N = g.A.Count();
            #region пример
            //const int N = 10;
            //int smezh[N][N] =
            //{
            //    { 0,10,0,0,20,0,0,15,0,0},
            //    { 10,0,5,0,0,0,0,2,8,9},
            //    { 0,5,0,16,0,0,0,0,4,0},
            //    { 0,0,16,0,28,25,0,0,11,9},
            //    { 20,0,0,28,0,15,0,0,0,0},
            //    { 0,0,0,25,15,0,10,0,7,5},
            //    { 0,0,0,0,0,10,0,11,0,3},
            //    { 15,2,0,0,0,0,11,0,4,14},
            //    { 0,8,4,11,0,7,0,4,0,0},
            //    { 0,9,0,9,0,5,3,14,0,0}
            //};
            #endregion
            //создание
            string output = "";
            int sum = 0, vertices = 0;
            int min = int.MaxValue;
            List<int> minn = new List<int>();
            List<int> versh = new List<int>();
            List<List<int>> buf = new List<List<int>>();
            //--------

            var b = Enumerable.Repeat(0, N).ToList();
            var vert = Enumerable.Repeat(b, N).ToList();

            for (int i = 0; i<N; i++) {
                for (int j = i; j<N; j++) {
                    if (g.A[i][j] > 0) {
                        min = g.A[i][j];
                        minn.Add(min);
                    }
                }
            }

            minn.Sort();

            for (int z = 0; z < minn.Count(); z++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = i; j < N; j++)
                    {
                        if (minn[z] == g.A[i][j])
                        {
                            #region проверка/старые примеры/др
                            /*for (int k = 0; k < N; k++) {
                                int degr = 0;
                                for (int f = k; f < N; f++)
                                    if (vert[k][f])
                                        degr += 1;
                                if (degr > 0 && degr < 3) {
                                    t = false;
                                    break;
                                }
                            }*///проверка на циклы(-)
                            vert[i][j] = vert[j][i] = minn[z];
                            int flag = 0;
                            int gf = 0;
                            /*поиск циклов через обрезанный поиск*/
                            for (int r = 0; r < N; r++)
                            {
                                flag = 0;
                                int y = 0;
                                /*проверка на единичную вершину*/
                                for (int h = 0; h < N; h++)
                                    if (vert[r][h] != 0)
                                        y++;
                                /*-----------------------------*/

                                if (y != 1)
                                {
                                    a_cycles cyc = new a_cycles();
                                    flag = cyc.dfs_cut(i, i, N, 0, vert);
                                }

                                if (flag == -1)
                                    gf += flag;
                            }
                            /*-----------------------------------*/
                            #endregion

                            if (gf < 0)
                                vert[i][j] = vert[j][i] = 0;
                            else
                            {
                                List<int> ver = new List<int>();
                                bool fl = true;
                                ver.Add(i);
                                ver.Add(j);
                                for (int k = 0; k < buf.Count(); k++)
                                    if (buf[k][0] == versh[0] && buf[k][1] == versh[1])
                                        fl = false;
                                if (fl)
                                {
                                    sum += minn[z];
                                    output += $"{i} - {j} Weight: {minn[z]}. Interim amount: {sum}\n";
                                    buf.Add(versh);
                                }
                            }
                        }
                    }
                }
            }
            return output;
        }
    }
}
