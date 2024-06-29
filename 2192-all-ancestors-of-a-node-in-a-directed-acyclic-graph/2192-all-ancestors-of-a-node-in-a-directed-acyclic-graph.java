class Solution {
    public List<List<Integer>> getAncestors(int n, int[][] edges) {
        // build adjacency list
        List<Integer>[] adjList = new ArrayList[n];
        for(var i=0; i<n; i++) adjList[i] = new ArrayList<>();
        for(var edge : edges) adjList[edge[1]].add(edge[0]);    // reverse direction
        
        var ans = new ArrayList<List<Integer>>();
        
        // perform dfs
        for(var node=0; node<n; node++){
            var ancestors = new ArrayList<Integer>();
            var visited = new boolean[n];
            findChildren(adjList, visited, node);

            // add all visited nodes to the ancestors list
            for(var parent=0; parent<n; parent++)
                if(parent != node && visited[parent])
                    ancestors.add(parent);
            
            ans.add(ancestors);
        }

        return ans;
    }

    private void findChildren(List<Integer>[] adjList, boolean[] visited, int curr){
        visited[curr] = true;
        for(var next : adjList[curr])
            if(!visited[next])
                findChildren(adjList, visited, next);
    }
}