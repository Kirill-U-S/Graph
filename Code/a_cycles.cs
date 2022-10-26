using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: все те же проблемы с поиском циклов/решить/доделать/переделать
//поиск циклов и вывод их на экран
//
//TODO: Сложность алгоритма весьма высокая, поэтому, как мне кажется, стоит придумать оптимизацию
namespace Graph
{
    class a_cycles
    {//TODO: к dfs и bfs надо будет разработать нормальный интерфейс взаимодействия
		public int dfs_cut(int nach, int v, int N, int path_dlina, List<List<int>> arr)
		{ 
			path_dlina++;
			for (int u = 0; u < N; u++)
			{
				int y = 0;
				if (arr[v][u] > 0)
				{
					if (u != nach)
					{
						List<List<int>> copy = new List<List<int>>();
						List<int> g = new List<int>();
                        
						//-----копирование--------
                        for (int i = 0; i < N; i++)
                        {
							for (int j = 0; j < N; j++)
								g = g.Append(0).ToList();
							copy = copy.Append(g).ToList();
                        }

						for (int i = 0; i < N; i++)
							for (int j = 0; j < N; j++)
								copy[i][j] = arr[i][j];
						//-------------------------

						copy[v][u] = 0;
						copy[u][v] = 0;

						y = dfs_cut(nach, u, N, path_dlina, copy);
					}
					else if (u == nach && path_dlina > 2)
					{
						return -1;
					}
				}
				if (y == -1)
					return y;
			}
			return 0;
		}

        public void dfs(int u, List<List<int>> arr, List<int> path, List<bool> versh, int dlina, ref List<List<int>> arrpath, int N)
        {
            path = path.Append(u).ToList();  //вершина с которой мы работаем
            dlina++;
            versh[u] = true;

            for (int v = 0; v < N; v++)
            {
                if (arr[u][v] > 0)
                {     //если между вершинами есть ребро
                    if (v != path[0] && !versh[v])
                    {  //вершинку мы сравниваем с начальной вершиной пути(см 76 строка) и чтобы versh был не равен тру
                        dfs(v, arr, path, versh, dlina, ref arrpath, N);
                    }
                    else if (v == path[0] && dlina > 2)
                    {    //используем начальную вершинку и чтобы мы не ходили по одному и тому же ребру(т е вершин задействовано больше двух)
                        arrpath = arrpath.Append(path).ToList();   //весь путь добавляем к вектору arrpath
                    }
                }
            }
            versh[u] = false;
        }
        #region нерабочий бфс
        /*---бфс на данный момент нерабочий, но я его оставляю, если он тебе будет интересен---*/
        void bfs(int N, int u, int dlina, Dictionary<int, bool> edges, Dictionary<int, string> E, List<List<int>> arr, List<int> path, ref List<List<int>> arrpath)
		{
			path = path.Append(u).ToList();  //вершина с которой мы работаем
			dlina++;

			for (int v = 0; v < arr.Count; v++)
			{
				if (arr[u][v] > 0)
				{
					if (E.ContainsKey(u * N + v) && !edges.ContainsKey(u * N + v) && v != path[0])
					{
						edges.Add(u * N + v, true);
						bfs(N, v, dlina, edges, E, arr, path, ref arrpath);
						edges.Remove(u * N + v);
					}
					else if (v == path[0] && dlina > 2)
						arrpath = arrpath.Append(path).ToList();
				}
			}
		}
        /*---*/
        #endregion
        public string to_dfs(Graph g)
		{
			int N = g.A.Count();
			int dlina = 0;

			List<List<int>> arrpath = new List<List<int>>();
			List<int> path = new List<int>();
			List<bool> versh = new List<bool>();
			#region инициализация
            for (int i = 0; i < N; i++)
            {
				versh = versh.Append(false).ToList();
            }
			#endregion

            #region пример
            /*-работающие примеры-*/
            /* int arr[N][N] = {
				 {0, 1, 1, 0},
				 {1, 0, 1, 1},
				 {1, 1, 0, 1},
				 {0, 1, 1, 0}
			 };*/

            /*int arr[N][N] = {
				{0, 1, 1, 0, 0},
				{1, 0, 1, 0, 0},
				{1, 1, 0, 1, 1},
				{0, 0, 1, 0, 1},
				{0, 0, 1, 1, 0}
			};
			*/
            /*--------------------*/
            #endregion

            /*-алгоритм-*/
            for (int i = 0; i < N; i++)
				dfs(i, g.A, path, versh, dlina, ref arrpath, N);
			/*----------*/

			/*-буферный массив-*/
			List<List<List<int>>> buf = new List<List<List<int>>>();

            /*-сортировка по размеру циклов-*/
			//TODO: Hepa6oTaeT Haxyu
      //      for (int i = 0; i < arrpath.Count() - 1; i++)
      //      {
      //          for (int j = 0; j < arrpath.Count() - i - 1; j++)
      //          {
      //              if (arrpath[j].Count() > arrpath[j + 1].Count())
      //              {
						//var bb = arrpath[j + 1];
						//arrpath[j] = arrpath[j + 1];
						//arrpath[j + 1] = bb;
      //              }
      //          }
      //      }
			/*------------------------------*/

			/*-добавление имеющегося массива циклов-*/
			//buf = buf.Append(arrpath).ToList();
			buf.Add(arrpath);
            /*--------------------------------------*/

            #region некоторое преобразование к удобному виду
            //for (int i = 0; i < buf[0].Count(); i++)
            //{
            //	/*-сортировка путей векторов-*/
            //	//sort(buf[0][i].begin(), buf[0][i].end());
            //	buf[0][i].Sort();
            //}

            /*-исключение одинаковых векторов-*/
            //for (int i = 0; i < buf[0].Count(); i++)
            //{
            //	for (int j = 0; j < buf[0].Count(); j++)
            //	{
            //		if (i != j && buf[0][i].Count() == buf[0][j].Count())
            //		{
            //			bool flag = true;
            //			for (int k = 0; k < buf[0][i].Count(); k++)
            //				if (buf[0][i][k] != buf[0][j][k])
            //					flag = false;

            //			if (flag)
            //				for (int k = 0; k < buf[0][j].Count(); k++)
            //					buf[0][j][k] = -1;                      //если элементы повторяются
            //		}
            //	}
            //}
            /* --------------------------------*/
            #endregion

            #region-вывод-
            string output = "";
            for (int i = 0; i < buf[0].Count(); i++)
			{
				for (int j = 0; j < buf[0][i].Count(); j++)
				{
					if (buf[0][i][j] == -1)
						break;
					else
						output += buf[0][i][j] + " ";
				}

				if(buf[0][i].Count > 0)
					if (buf[0][i][0] != -1)
						output += buf[0][i][0] + "\n";
			}
            #endregion
            return output;

			# region вынести в отдельную функцию
			//TODO: вынести в отдельную функцию:::::
			//нахождение обхвата и периметра графа
			int girth = buf[0][0].Count(); //обхват
			int P = buf[0][buf[0].Count() - 1].Count();
            //std::cout << "girth: " << girth << std::endl;
            //std::cout << "perimetr: " << P << std::endl;  //TODO: протестировать!
            #endregion

        }
    }
}