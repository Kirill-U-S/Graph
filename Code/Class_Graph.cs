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
        public List<string> E { get; set; }

		/*---стандартный конструктор---*/
		public Graph()
        {
			A = new List<List<int>>();
			E = new List<string>();
			D = new List<List<int>>();
		}
		/*---конструктор создающий граф с нулевой таблицей смежности и т.д.---*/
		public Graph(int V)
        {
			A = new List<List<int>>();
			E = new List<string>();
			D = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
				List<int> _buf = new List<int>();
				for (int j = 0; j < V; j++)
					_buf.Add(0);

				A.Add(_buf);
			}
		}

		/*---задание через матрицу инцидентности---*/
		public Graph(int V, string str)
		{
			A = new List<List<int>>();
			E = new List<string>();
			D = new List<List<int>>();
            for (int k = 0; k < V; k++)
            {
				List<int> _buf = new List<int>();
				for (int i = 0; i < V; i++)
					_buf.Add(0);

				A.Add(_buf);
            }
            {
				int y = 0;
				List<int> buf = new List<int>();
				for (int i = 0; i < str.Length; i++)
				{
					if(str[i] == ' ')
					{
						string buf_str = "";
						for (int k = i+1; k < str.Length; k++)
						{
							if (str[k] != ' ')
								buf_str += str[k];
							else
								break;
						}

						if(buf_str.Length > 0)
						{
							buf.Add(int.Parse(buf_str));
						}
						if(buf.Count == V)
						{
							for (int k = 0; k < V; k++)
								A[y][k] = buf[k];
							buf.Clear();
							y++;
						}
					}
				}

			}
			/*добавление Edges|массив Е здесь выступает просто как массив строк*/
			for (int i = 0; i < V; i++)
			{
				for (int j = i; j < V; j++)
				{
					if (A[i][j] != 0)
					{
						string buf = $"{i}{j}";
						E = E.Append(buf).ToList();
					}
					if (A[j][i] != 0)
					{
						string buf = $"{j}{i}";
						E = E.Append(buf).ToList();
					}
				}
			}

			/*---TODO: на данный момент неясно, что мы будем окончательно использовать - List Е или Dictionary E---*/
			/*---TODO: поэтому оставляю две версии, одну закоменченную, если тебя она будет интересовать ---*/
			/*добавление Edges| массив Е здесь выступает как Dictionary*/
			//E = new Dictionary<int, string>();
			//for (int i = 0; i < V; i++)
			//{
			//	for (int j = i; j < V; j++)
			//	{
			//		if (A[i][j] != 0)
			//		{
			//			string buf = $"{i}{j}";
			//			E.Add(i * V + j, buf);
			//		}
			//		if (A[j][i] != 0)
			//		{
			//			string buf = $"{j}{i}";
			//			E.Add(j * V + i, buf);
			//		}
			//	}
			//}
		}
		/*---обрубил данную реализацию до момента, когда мы наконец определимся с Е---*/
		/*задание через <V, E>*/
		//Graph(int V, int reb)
		//{
		//	for (int i = 0; i < V; i++)
		//	{
		//		List<int> buf = new List<int>();
		//		for (int j = 0; j < reb; j++)
		//		{
		//			int w = 0;
		//			//прилет данных std::cin >> w;
		//			buf.Add(w);
		//		}
		//		D.Add(buf);
		//	}

		//	for (int j = 0; j < reb; j++)
		//	{
		//		int p = 0;
		//		int znach = 0;
		//		for (int i = 0; i < V; i++)
		//		{
		//			if (D[i][j] != 0)
		//			{
		//				p++;
		//				znach = D[i][j];
		//			}
		//		}
		//		if (p == 2)
		//			E.Add(znach);
		//		//else if (p > 0 && p != 2)
		//		//	вылет ошибкки std::cout << "ERROR: задание через <V, E>, ошибка в массиве\n";
		//	}
		//}

		/*----------алгоритмы----------*/

		public string a_cycles()
        {
			a_cycles cycle = new a_cycles();
			return cycle.to_dfs(this);
        }
        public int a_cycles_cut(int nach, int v, int N, int path_dlina, List<List<int>> arr)
        {
			a_cycles cycle = new a_cycles();
			return cycle.dfs_cut(nach, v, N, path_dlina, arr);
        }
		//public int a_cycles_dfs(int u, List<List<int>> arr, List<int> path, List<bool> versh, int dlina, ref List<List<int>> arrpath, int N)
		//{
		//	a_cycles cycle = new a_cycles();
		//	return cycle.dfs(u, arr, path, versh, dlina, ref arrpath, N);
		//}
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
		public string f_hamiltonian()
		{
			f_hamiltonian ham = new f_hamiltonian();
			return ham.hamiltonian(this);
		}
		public string a_prima()
        {
			a_prima prim = new a_prima();
			return prim.method(this);
        }
        public string f_complete()
        {
			f_complete comp = new f_complete();
			return comp.f_comp(this);
        }
		public string f_connect()
		{
			f_connect comp = new f_connect();
			return comp.f_con(this);
		}
		public string f_multi()
        {
			f_multi mult = new f_multi();
			return mult.f_mul(this);
        }
		public string f_psevdo()
		{
			f_psevdo psev = new f_psevdo();
			return psev.f_psev(this);
		}
		public string f_regular()
		{
			f_regular regul = new f_regular();
			return regul.f_regul(this);
		}
		public string m_adtograph()
		{
			m_adtograph ad = new m_adtograph();
			return ad.m_ad(this);
		}
		public string o_degree()
		{
			o_degree deg = new o_degree();
			return deg.o_deg(this);
		}
		public string m_reachability()
		{
			m_reachability reach = new m_reachability();
			return reach.m_reach(this);
		}
		public string o_distances()
		{
			o_distances dis = new o_distances();
			return dis.o_dis(this);
		}
	}
}
