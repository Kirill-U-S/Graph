using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	class f_hamiltonian
	{
		public string hamiltonian(Graph g)
		{
			int N = g.A.Count();
			int dlina = 0;
			bool flag = false;

			List<List<int>> arrpath = new List<List<int>>();
			List<List<int>> arr = new List<List<int>>();
			List<int> path = new List<int>();
			List<bool> versh = new List<bool>();

			#region копирование
			/*-копирование изначального массива А-*/

			/*-инициализация-*/
			for (int i = 0; i < N; i++)
			{
				List<int> b = new List<int>();
				for (int j = 0; j < N; j++)
					b = b.Append(0).ToList();
				arr = arr.Append(b).ToList();
			}
			/*---------------*/
			for (int i = 0; i < N; i++)
			{
				versh = versh.Append(false).ToList();
			}

			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					arr[i][j] = g.A[i][j];

			/*------------------------------------*/
			#endregion

			#region пример
			/*-работающие примеры-*/
			/* int arr[N][N] = {
				 {0, 1, 0, 1},
				 {1, 0, 1, 1},
				 {0, 1, 0, 1},
				 {1, 1, 1, 0}
			 };*/
			/*--------------------*/
			#endregion

			/*-алгоритм-*/
			for (int i = 0; i < N; i++)
			{
				a_cycles humm = new a_cycles();
				humm.dfs(i, arr, path, ref versh, ref dlina, ref arrpath, N);
			}
			/*----------*/

			/*-вывод-*/
			string output = "";
			for (int i = 0; i < arrpath.Count(); i++)
			{
				if (arrpath[i].Count() == N)
                {
					flag = true;
					break;
                }
					
			}
			if (flag)
				output += "graph is hamiltonian";
			else
				output += "graph is not hamiltonian";
			return output;
		}
	}
}