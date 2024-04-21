public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        var graph = EdgesToGraph(n, edges);
        
        var visited = new bool[n];
        var queue = new Queue<int>();
        queue.Enqueue(source);
        visited[source] = true;

        // BFS
        while(queue.Count > 0){
            var count = queue.Count;
            for(var i=0; i<count; i++){
                var src = queue.Dequeue();
                if(src == destination) return true;
                foreach(var dest in graph[src]){
                    if(visited[dest]) continue;
                    visited[dest] = true;
                    queue.Enqueue(dest);
                }
            }
        }

        return false;
    }

    private List<int>[] EdgesToGraph(int n, int[][] edges){
        var graph = new List<int>[n];
        for(var i=0; i<n; i++) graph[i] = new List<int>();

        foreach(var edge in edges){
            var (s, d) = (edge[0], edge[1]);
            graph[s].Add(d);
            graph[d].Add(s);
        }

        return graph;
    }
}