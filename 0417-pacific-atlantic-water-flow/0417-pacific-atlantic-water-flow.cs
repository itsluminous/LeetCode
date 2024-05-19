// dfs with memoization
public class Solution {
    bool[,] atlantic, pacific;
    private IList<IList<int>> ans;

    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        atlantic = new bool[m, n];
        pacific = new bool[m, n];
        ans = new List<IList<int>>();

        // start from border and figure out which all cells are eligible to reach that border
        for(var i=0; i<m; i++){
            DFS(heights, pacific, i, 0);        // leftmost cols
            DFS(heights, atlantic, i, n - 1);   // rightmost cols
        }
        
        for(var i=0; i<n; i++){
            DFS(heights, pacific, 0, i);        // topmost row
            DFS(heights, atlantic, m - 1, i);   // last row
        }

        return ans;
    }

    private void DFS(int[][] heights, bool[,] visited, int i, int j){
        int m = heights.Length, n = heights[0].Length;
        if (visited[i, j]) return;
        visited[i, j] = true;

        if (atlantic[i, j] && pacific[i, j]) ans.Add([i,j]);

        if (i + 1 < m && heights[i + 1][j] >= heights[i][j]) DFS(heights, visited, i + 1, j);
        if (i - 1 >= 0 && heights[i - 1][j] >= heights[i][j]) DFS(heights, visited, i - 1, j);
        if (j + 1 < n && heights[i][j + 1] >= heights[i][j]) DFS(heights, visited, i, j + 1);
        if (j - 1 >= 0 && heights[i][j - 1] >= heights[i][j]) DFS(heights, visited, i, j - 1);
    }
}