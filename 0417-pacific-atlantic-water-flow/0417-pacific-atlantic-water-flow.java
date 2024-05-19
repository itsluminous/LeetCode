// dfs with memoization
class Solution {
    private boolean[][] atlantic, pacific;
    private List<List<Integer>> ans;

    public List<List<Integer>> pacificAtlantic(int[][] heights) {
        int m = heights.length, n = heights[0].length;
        atlantic = new boolean[m][n];
        pacific = new boolean[m][n];
        ans = new ArrayList<>();

        // start from border and figure out which all cells are eligible to reach that border
        for(var i=0; i<m; i++){
            dfs(heights, pacific, i, 0);        // leftmost cols
            dfs(heights, atlantic, i, n - 1);   // rightmost cols
        }
        
        for(var i=0; i<n; i++){
            dfs(heights, pacific, 0, i);        // topmost row
            dfs(heights, atlantic, m - 1, i);   // last row
        }

        return ans;
    }

    private void dfs(int[][] heights, boolean[][] visited, int i, int j){
        int m = heights.length, n = heights[0].length;
        if (visited[i][j]) return;
        visited[i][j] = true;

        if (atlantic[i][j] && pacific[i][j]) ans.add(Arrays.asList(i, j));

        if (i + 1 < m && heights[i + 1][j] >= heights[i][j]) dfs(heights, visited, i + 1, j);
        if (i - 1 >= 0 && heights[i - 1][j] >= heights[i][j]) dfs(heights, visited, i - 1, j);
        if (j + 1 < n && heights[i][j + 1] >= heights[i][j]) dfs(heights, visited, i, j + 1);
        if (j - 1 >= 0 && heights[i][j - 1] >= heights[i][j]) dfs(heights, visited, i, j - 1);
    }
}