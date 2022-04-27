public class Solution {
    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        var n = s.Length;
        
        // convert all pairs to graph
        var graph = new List<int>[n];
        var visited = new bool[n];
        for(var i=0; i<n; i++)
            graph[i] = new List<int>();
        
        foreach(var p in pairs){
            int src = p[0], dest = p[1];
            graph[src].Add(dest);
            graph[dest].Add(src);
        }
        
        // create final string
        var result = new char[n];
        for(var v=0; v<n; v++){
            if(visited[v]) continue;
            var chars = new List<char>();
            var indices = new List<int>();
            
            DFS(graph, visited, s, v, chars, indices);
            chars.Sort();
            indices.Sort();
            
            // Store the sorted characters corresponding to the index
            for(var i=0; i<chars.Count; i++)
                result[indices[i]] = chars[i];
        }
        
        return new string(result);
    }
    
    private void DFS(List<int>[] graph, bool[] visited, string s, int vertex, List<char> chars, List<int> indices){
        // add the chars and their indices to list
        chars.Add(s[vertex]);
        indices.Add(vertex);
        
        visited[vertex] = true;
        
        // traverse the adjacents
        foreach(var node in graph[vertex]){
            if(!visited[node])
                DFS(graph, visited, s, node, chars, indices);
        }
    }
}