#include "D:/help/feat.hpp"



vector< pair<int, int> > PrimasAlgo(vector <vector<int> > &a, int from) {
    vector<int> subGraph;
    vector< pair<int, int> > edges;

    subGraph.push_back(from);
    setCol(a, from, INF);


    while (subGraph.size() < a.size()) {
        
        int Min = INF - 1;
        pair<int, int> MinIndex;

        // Ищем минимальное ребро из списка подграфа
        for (int i : subGraph) {
            for (int j = 0; j < a[i].size(); j++) {
                if (a[i][j] < Min) {
                    Min = a[i][j];
                    MinIndex = make_pair(i, j);
                }
            }
        }


        subGraph.push_back(MinIndex.second);
        edges.push_back(MinIndex);

        // удаляем лишние ребра (в уже подключенные вершины)
        setCol(a, MinIndex.second, INF);

    }
    
    return edges;
}


vector< pair<int, pair<int, int>> > getEdgeList(vector< vector<int> > &a) {
    int n = a.size();
    vector< pair<int, pair<int, int>> > edges(n);

    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            if (a[i][j] != INF) {
                edges.push_back(make_pair(a[i][j], make_pair(i, j)));
            }
        }
    }

    return edges;
}



vector< pair<int, int> > KruskalAlgo(vector <vector<int> > &a) {
    auto edges = getEdgeList(a);
    int m = edges.size();
    int n = a.size();

    sort(edges.begin() , edges.end());
    

    int cost = 0;

    vector < pair<int, int> > res;
    vector<int> tree_id(n);

    for (int i = 0; i < n; ++i)
        tree_id[i] = i;

    for (int i = 0; i < m; ++i)
    {
        int a = edges[i].second.first, b = edges[i].second.second, l = edges[i].first;

        if (tree_id[a] != tree_id[b])
        {
            cost += l;
            cout << a << " " << b << "\n";
            res.push_back(make_pair(a, b));

            int old_id = tree_id[b], new_id = tree_id[a];
            for (int j = 0; j < n; ++j)
                if (tree_id[j] == old_id)
                    tree_id[j] = new_id;
        }
    }

    return res;
}


int main()
{
    int n;
    cin >> n;

    vector< vector<int> > a(n, vector<int> (n));
    cinMatrix(a, 0);

    /*
        7
        0 0 1 0 0 0 0
        0 0 0 0 0 0 0
        0 0 0 7 0 11 0
        0 4 0 0 1 6 9
        0 3 0 0 0 0 10
        0 0 0 0 0 0 2
        0 0 0 0 0 0 0
    */

    cout << "1) Prima's algorithm \n";
    cout << "2) Kruskal's algorithm \n";

    int ans;
    cin >> ans;

    if (ans == 1) {
        cout << "Start from: \n";
        int from;
        cin >> from;

        auto res = PrimasAlgo(a, from);
        printVectorPairs(res);
    }

    if (ans == 2) {
        
        auto res = KruskalAlgo(a);
        printVectorPairs(res);
    }


}

