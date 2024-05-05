class Solution {
    List<Integer>[] graph;    // dest will be negative for opposite direction
    boolean[] visited;

    public int minReorder(int n, int[][] connections) {
        visited = new boolean[n];
        graph = new List[n];
        for(var i=0; i<n; i++) graph[i] = new ArrayList<Integer>();

        // add edge from both side
        for(var con : connections){
            graph[con[0]].add(con[1]);
            graph[con[1]].add(-con[0]);
        }

        return getCount(0); // start counting from node 0
    }

    private int getCount(int node){
        var count = 0;
        visited[node] = true;
        for(var dest : graph[node]){
            if(visited[Math.abs(dest)]) continue;
            if(dest > 0) count++;
            count += getCount(Math.abs(dest));
        }
        return count;
    }
}