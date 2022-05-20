// DP : keep track of number of ways to reach current point
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        if (obstacleGrid[0][0] == 1) return 0;
        
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        var row = new int[n];
        row[0] = 1;   // initialize first cell. If its an obstacle, we will handle in line 10
        
        for(int i=0; i<m; i++){
            row[0] = obstacleGrid[i][0] == 1 ? 0 : row[0];
            for(int j=1; j<n; j++){
                row[j] = obstacleGrid[i][j] == 1 ? 0 : row[j-1] + row[j];
            }
        }
        
        return row[n-1];
    }
}

// TLE : Recursive
public class Solution1 {
    int count = 0;
    
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        UniquePathsWithObstacles(obstacleGrid, 0, 0);
        return count;
    }
    
    public void UniquePathsWithObstacles(int[][] obstacleGrid, int x, int y) {
        int m = obstacleGrid.Length, n = obstacleGrid[0].Length;
        if(x == m || y == n || obstacleGrid[x][y] == 1)
            return;
        if(x == m-1 && y == n-1){
            count++;
            return;
        }
        
        UniquePathsWithObstacles(obstacleGrid, x+1, y);
        UniquePathsWithObstacles(obstacleGrid, x, y+1);
    }
}