public class Solution {
    List<int>[] graph;    // dest will be negative for opposite direction
    bool[] visited;

    public int MinReorder(int n, int[][] connections) {
        visited = new bool[n];
        graph = new List<int>[n];
        for(var i=0; i<n; i++) graph[i] = new List<int>();

        // add edge from both side
        foreach(var con in connections){
            graph[con[0]].Add(con[1]);
            graph[con[1]].Add(-con[0]);
        }

        return GetCount(0); // start counting from node 0
    }

    private int GetCount(int node){
        var count = 0;
        visited[node] = true;
        foreach(var dest in graph[node]){
            if(visited[Math.Abs(dest)]) continue;
            if(dest > 0) count++;
            count += GetCount(Math.Abs(dest));
        }
        return count;
    }
}