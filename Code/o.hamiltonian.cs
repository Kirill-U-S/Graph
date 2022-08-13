using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class o_hamiltonian
    {
		public string hamiltonian(Graph g)
		{
			int N = g.A.Count();
			int dlina = 0;
			bool flag = false;

			List<List<int>> arrpath = new List<List<int>>();
			List<List<int>> arr = new List<List<int>>(); ;
			List<bool> versh = Enumerable.Repeat(false, N).ToList();

			List<int> path = new List<int>();

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
				dfs(i, arr, path, ref versh, ref dlina, ref arrpath, N); //эта функция работает, если не объявлена тут?
			/*----------*/

			/*-буферный массив-*/
			List<List<List<int>>> buf = new List<List<List<int>>>();

			/*-добавление имеющегося массива циклов-*/
			//buf = buf.Append(arrpath).ToList();
			buf.Add(arrpath);
			/*--------------------------------------*/
			/*-отрезание концов-*/
			for (int i = 0; i < buf[0].Count(); i++)
				buf[0][i].RemoveAt(buf[0][i].Count() - 1);

			/*-вывод-*/
			string output = "";
			for (int i = 0; i < buf[0].Count(); i++)
			{
				for (int j = 0; j < buf[0][i].Count(); j++)
				{
					if (buf[0][i][j] == -1)
						break;
					else
						gam++;
				}
				if (gam == N)
				{
					flag = true;
					break;
				}
			}
			if (flag)
				output = "graph is hamiltonian";
			else
				output = "graph is not hamiltonian";
			return output;
		}
	}
}