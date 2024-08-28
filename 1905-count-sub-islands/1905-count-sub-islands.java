class Solution {
    public int countSubIslands(int[][] grid1, int[][] grid2) {
        int m = grid1.length, n = grid1[0].length;

        // grid1
        Map<String, String> parent = new HashMap<>();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                    dfs(grid1, parent, i, j, i+":"+j);

        // grid2
        var count = 0;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                if(grid2[i][j] == 1){
                    var p = parent.getOrDefault(i+":"+j, "something");
                    count += dfs2(grid2, parent, i, j, p);
                }   
            }
        }

        return count;
    }

    private void dfs(int[][] grid, Map<String, String> parent, int i, int j, String p){
        int m = grid.length, n = grid[0].length;
        if(i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0) return;
        parent.put(i+":"+j, p);
        grid[i][j] = 0;
        dfs(grid, parent, i-1, j, p);
        dfs(grid, parent, i+1, j, p);
        dfs(grid, parent, i, j-1, p);
        dfs(grid, parent, i, j+1, p);
    }

    private int dfs2(int[][] grid, Map<String, String> parent, int i, int j, String p){
        int m = grid.length, n = grid[0].length;
        if(i == -1 || i == m || j == -1 || j == n || grid[i][j] == 0) return 1;

        grid[i][j] = 0;
        var match = 1;
        match &= dfs2(grid, parent, i-1, j, p);
        match &= dfs2(grid, parent, i+1, j, p);
        match &= dfs2(grid, parent, i, j-1, p);
        match &= dfs2(grid, parent, i, j+1, p);

        if(!parent.containsKey(i+":"+j) || !parent.get(i+":"+j).equals(p)) return 0;
        return match;
    }
}