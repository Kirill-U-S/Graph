using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    //TODO: нихера не работает доработать/переделать
    class a_dijkstra
    {
		public void a_dMethod(int V_O, int v, List<List<int>> arr, List<bool> versh, List<int> path, List<int> weigth_path, ref List<List<int>> arrpath)
		{
			path = path.Append(v).ToList();
			versh[v] = true;

			for (int i = 0; i < V_O; i++)
			{
				if (!versh[i] && arr[v][i] > 0)
				{
					weigth_path = weigth_path.Append(arr[v][i]).ToList();

					a_dMethod(V_O, i, arr, versh, path, weigth_path, ref arrpath);
				}
			}

			/*-проверка на целостность пути-*/
			bool flag = true;
			for (int i = 0; i < V_O; i++)
				if (!versh[i])
					flag = false;

			/*-если путь целостный - записываю его значения-*/
			if (flag)
			{
				// for(int i = 0; i < path.size(); i++)
				// cout<<path[i]<< " ";
				arrpath = arrpath.Append(path).ToList();
				arrpath = arrpath.Append(weigth_path).ToList();
			}
		}

        #region пример
        //int main(){
        //	int N;
        //	int arr[4][4] = {
        //		{0, 2, 1, 0},
        //		{1, 0, 3, 1},
        //		{1, 1, 0, 1},
        //		{0, 4, 1, 0}
        //	};
        //	bool versh[4] = {false, false, false, false};
        //	vector<int> path;
        //	vector<int> weigth_path;
        //	vector<vector<int>> arrpath;
        //	
        //	/*-алгоритм-*/
        //	DA(4, 0, arr, versh, path, weigth_path, arrpath);
        //	
        //	/*-вывод-*/
        //	for(int i = 0; i < arrpath.size(); i++){
        //		for(int j = 0; j < arrpath[i].size(); j++){
        //			cout<<arrpath[i][j]<<" ";
        //		}
        //		cout<<"\n";
        //	}
        //}
        #endregion
    }
}
