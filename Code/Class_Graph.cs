using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
		public List<List<int>> A { get; set; }
        public List<List<int>> D { get; set; }
        public List<int> E { get; set; }

		/*задание через матрицу инцидентности*/
		public Graph(int V, string str)
		{
			str = str.Replace(" ", "");
			A = new List<List<int>>();
			for (int i = 0; i < V; i++)
			{
				var buf = Enumerable.Repeat(0, V).ToList();
				for (int j = 0; j < V; j++)
					buf[j] = int.Parse(str[i * V + j].ToString());

				A.Add(buf);
			}
		}

		/*задание через <V, E>*/
		Graph(int V, int reb)
		{
			for (int i = 0; i < V; i++)
			{
				List<int> buf = new List<int>();
				for (int j = 0; j < reb; j++)
				{
					int w = 0;
					//прилет данных std::cin >> w;
					buf.Add(w);
				}
				D.Add(buf);
			}

			for (int j = 0; j < reb; j++)
			{
				int p = 0;
				int znach = 0;
				for (int i = 0; i < V; i++)
				{
					if (D[i][j] != 0)
					{
						p++;
						znach = D[i][j];
					}
				}
				if (p == 2)
					E.Add(znach);
				//else if (p > 0 && p != 2)
				//	вылет ошибкки std::cout << "ERROR: задание через <V, E>, ошибка в массиве\n";
			}
		}

		/*----------алгоритмы----------*/

		public string a_cycles()
        {
			a_cycles cycle = new a_cycles();
			return cycle.find_cycles(this);
        }
		public string a_dijkstra()
        {
			a_dijkstra ad = new a_dijkstra();
			# region нужное-для-алгоритма
			List<bool> versh = Enumerable.Repeat(false, A.Count()).ToList();
			List<int> path = new List<int>();
			List<int> weigth_path = new List<int>();
			List<List<int>> arr_path = new List<List<int>>();
			ad.a_dMethod(A.Count(), 0, A, versh, path, weigth_path, ref arr_path);
            #endregion
            #region вывод
            string output = "";
			for (int i = 0; i < arr_path.Count(); i++)
            {
                for (int j = 0; j < arr_path[i].Count(); j++)
                {
					output += arr_path[i][j] + " ";
                }
				output += "\n";
            }
            #endregion
            return output;
        }
		public string a_kraskala()
        {
			a_kraskala kr = new a_kraskala();
			return kr.a_kraskal(this);
        }
		public string a_prima()
        {
			a_prima prim = new a_prima();
			return prim.method(this);
        }
	}
}
