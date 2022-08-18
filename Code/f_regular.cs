using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class f_regular
    {
		//регул¤рный ли граф(все вершины имеют одинаковую степень)
		public string f_regul(Graph g)
		{
			int N = g.A.Count();
			List<List<int>> smezh = new List<List<int>>();
			List<int> degr = new List<int>();
			int flag = 1;

			#region инициализация
			for (int i = 0; i < N; i++)
			{
				List<int> buf = new List<int>();
				for (int j = 0; j < N; j++)
					buf = buf.Append(0).ToList();

				smezh = smezh.Append(buf).ToList();
				degr = degr.Append(0).ToList();
			}
			#endregion
			#region копирование
			for (int i = 0; i < N; i++)
				for (int j = 0; j < N; j++)
					smezh[i][j] = g.A[i][j];
			#endregion

			for (int i = 0; i < N; i++)
			{
				degr[i] = 0;
				for (int j = 0; j < N; j++)
					degr[i] += smezh[i][j]; //массив со степен¤ми вершин
			}
			for (int k = 1; k < N; k++)
			{
				if (degr[k - 1] != degr[k])
				{
					flag = 0;
					break;
				}
			}
			if (flag > 0)
				return "regular";
			else
				return "unregular";
		}

	}
}
