class Solution {
    public int findCircleNum(int[][] isConnected) {
        int n = isConnected.length, province = 0;
        var visited = new boolean[n+1];
        for(var city=0; city<n; city++)
            if(dfs(isConnected, visited, city))
                province++;

        return province;
    }

    private boolean dfs(int[][] isConnected, boolean[] visited, int city){
        if(visited[city]) return false;
        visited[city] = true;

        for(var next=0; next<isConnected.length; next++){
            if(isConnected[city][next] == 0) continue;
            dfs(isConnected, visited, next);
        }
        return true;
    }
}