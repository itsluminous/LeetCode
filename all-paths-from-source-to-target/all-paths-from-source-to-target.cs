public class Solution {
    IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var visited = new bool[graph.Length];
        visited[0] = true;
        DFS(graph, visited, new List<int>{0}, 0);
        return result;
    }
    
    private void DFS(int[][] graph, bool[] visited, List<int> path, int node){
        if(node == graph.Length -1){
            result.Add(new List<int>(path));
            return;
        }
        
        var links = graph[node];
        for(var i=0; i<links.Length; i++){
            var curr = links[i];
            if(visited[curr]) continue;
            
            visited[curr] = true;
            path.Add(curr);
            DFS(graph, visited, path, curr);
            path.RemoveAt(path.Count - 1);
            visited[curr] = false;
        }
    }
}