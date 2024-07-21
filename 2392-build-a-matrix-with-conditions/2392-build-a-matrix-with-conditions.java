class Solution {
    boolean hasCycle = false;

    public int[][] buildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        var sortedRows = topologicalSort(rowConditions, k);
        var sortedCols = topologicalSort(colConditions, k);

        // if there is a cyclic dependency
        if(sortedRows.isEmpty() || sortedCols.isEmpty()) return new int[0][0];

        var matrix = new int[k][k];
        for(var i=0; i<k; i++)
            for(var j=0; j<k; j++)
                if(sortedRows.get(i).equals(sortedCols.get(j)))
                    matrix[i][j] = sortedRows.get(i);
        
        return matrix;
    }

    private List<Integer> topologicalSort(int[][] edges, int k){
        // build adj list
        List<Integer>[] graph = new List[k+1];
        for(var i=0; i<=k; i++)
            graph[i] = new ArrayList<>();
        for(var edge : edges)
            graph[edge[0]].add(edge[1]);
        
        // sort the vertices
        var sorted = new ArrayList<Integer>();
        var visited = new int[k+1];     // 1 = visiting, 2 = visited
        hasCycle = false;

        // perform dfs for sorting
        for(var i=1; i<=k; i++)
            if(visited[i] == 0){
                dfs(graph, visited, sorted, i);
                if(hasCycle) return new ArrayList<>();
            }
        
        Collections.reverse(sorted);
        return sorted;
    }

    private void dfs(List<Integer>[] graph, int[] visited, List<Integer> sorted, int node){
        visited[node] = 1;  // visiting
        for(var next : graph[node]){
            if(visited[next] == 0){
                dfs(graph, visited, sorted, next);
                if(hasCycle) return;
            }
            else if(visited[next] == 1){
                hasCycle = true;
                return;
            }
        }

        visited[node] = 2;  // visited
        sorted.add(node);
    }
}