using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class a_kraskala
    {
        //проверено |при последне проверке убран пример|
        public string a_kraskal(Graph g)
        {
            int N = g.A.Count();
            string output = "";
            int sum = 0;
            int min = int.MaxValue;
            List<int> minn = new List<int>();
            List<int> versh = new List<int>();
            List<List<int>> vert = new List<List<int>>();
            List<List<int>> buf = new List<List<int>>();
            #region-инициализация-
            for (int i = 0; i < N; i++)
            {
                List<int> b = new List<int>();
                for (int j = 0; j < N; j++)
                    b = b.Append(0).ToList();
                vert = vert.Append(b).ToList();
            }
            #endregion
            #region-копирование-
            for (int i = 0; i<N; i++) {
                for (int j = i; j<N; j++) {
                    if (g.A[i][j] > 0) {
                        min = g.A[i][j];
                        minn.Add(min);
                    }
                }
            }
            #endregion
            
            minn.Sort();
            for (int z = 0; z < minn.Count(); z++)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = i; j < N; j++)
                    {
                        if (minn[z] == g.A[i][j])
                        {
                            #region проверка
                            vert[i][j] = vert[j][i] = minn[z];
                            int gf = 0;
                            /*поиск циклов через обрезанный поиск*/
                            for (int r = 0; r < N; r++)
                            {
                                int flag = 0;
                                int y = 0;
                                /*проверка на единичную вершину*/
                                for (int h = 0; h < N; h++)
                                    if (vert[r][h] != 0)
                                        y++;
                                /*-----------------------------*/
                                //проверка на наличие цикла
                                if (y != 1)
                                {
                                    a_cycles cyc = new a_cycles();
                                    flag = cyc.dfs_cut(i, i, N, 0, vert);
                                }
                                //-1 - если цикл есть
                                if (flag == -1)
                                {
                                    gf += flag;
                                    break;
                                }
                            }
                            /*-----------------------------------*/
                            #endregion

                            if (gf < 0)
                                vert[i][j] = vert[j][i] = 0;
                            else
                            {
                                List<int> ver = new List<int>();
                                bool fl = true;
                                ver = ver.Append(i).ToList();
                                ver = ver.Append(j).ToList();
                                for (int k = 0; k < buf.Count(); k++)
                                    if (buf[k][0] == ver[0] && buf[k][1] == ver[1])
                                        fl = false;
                                if (fl)
                                {
                                    sum += minn[z];
                                    output += $"{i} - {j} Weight: {minn[z]}. Interim amount: {sum}\n";
                                    buf.Add(ver);
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
