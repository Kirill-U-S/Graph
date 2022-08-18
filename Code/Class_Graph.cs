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

		/*задание через матрицу инцидентности*/
		public Graph(int V, string str)
		{
			A = new List<List<int>>();
			E = new List<string>();
            for (int k = 0; k < V; k++)
            {
				List<int> _buf = new List<int>();
				for (int i = 0; i < V; i++)
				{
					_buf.Add(0);
				}
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
			return cycle.find_cycles(this);
        }
        public int a_cycles_cut(int nach, int v, int N, int path_dlina, List<List<int>> arr)
        {
			a_cycles cycle = new a_cycles();
			return cycle.dfs_cut(nach, v, N, path_dlina, arr);
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
		public string f_hamiltonian()
		{
			f_hamiltonian ham = new f_hamiltonian();
			return ham.hamiltonian(this);
		}
		public string f_complete_graph()
		{
			f_complete_graph com = new f_complete_graph();
			return com.complete(this);
		}
		public string a_prima()
        {
			a_prima prim = new a_prima();
			return prim.method(this);
        }
	}
}
