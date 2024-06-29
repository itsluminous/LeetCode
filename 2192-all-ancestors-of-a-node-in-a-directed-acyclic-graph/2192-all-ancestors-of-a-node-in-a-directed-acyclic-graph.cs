public class Solution {
    public IList<IList<int>> GetAncestors(int n, int[][] edges) {
        // build adjacency list
        var adjList = new List<int>[n];
        for(var i=0; i<n; i++) adjList[i] = new List<int>();
        foreach(var edge in edges) adjList[edge[1]].Add(edge[0]);    // reverse direction
        
        var ans = new List<IList<int>>();
        
        // perform dfs
        for(var node=0; node<n; node++){
            var ancestors = new List<int>();
            var visited = new bool[n];
            FindChildren(adjList, visited, node);

            // add all visited nodes to the ancestors list
            for(var parent=0; parent<n; parent++)
                if(parent != node && visited[parent])
                    ancestors.Add(parent);
            
            ans.Add(ancestors);
        }

        return ans;
    }

    private void FindChildren(List<int>[] adjList, bool[] visited, int curr){
        visited[curr] = true;
        foreach(var next in adjList[curr])
            if(!visited[next])
                FindChildren(adjList, visited, next);
    }
}