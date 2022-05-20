// DFS : Store max len for each point
public class Solution {
    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length, longest = 1;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var cache = new int[m,n];
                var l = LongestIncreasingPath(matrix, i, j, cache, -1);
                longest = Math.Max(longest, l);
            }
        }
        
        return longest;
    }
    
    private int LongestIncreasingPath(int[][] matrix, int x, int y, int[,] cache, int prev) {
        int m = matrix.Length, n = matrix[0].Length;
        if(x < 0 || y < 0 || x == m || y == n || matrix[x][y] <= prev )
            return 0;
        if(cache[x,y] != 0) return cache[x,y];
        
        var dirs = new []{new []{-1,0}, new []{1,0}, new []{0,-1}, new []{0,1}};
        var curr = 1;
        foreach(var dir in dirs){
            var val = 1 + LongestIncreasingPath(matrix, x+dir[0], y+dir[1], cache, matrix[x][y]);
            curr = Math.Max(curr, val);
        }
        cache[x,y] = curr;
        return curr;
    }
}

// TLE : DFS
public class Solution1 {
    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length, longest = 1;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var visited = new bool[m,n];
                var l = LongestIncreasingPath(matrix, i, j, visited, 0, -1);
                longest = Math.Max(longest, l);
            }
        }
        
        return longest;
    }
    
    private int LongestIncreasingPath(int[][] matrix, int x, int y, bool[,] visited, int length, int prev) {
        int m = matrix.Length, n = matrix[0].Length;
        if(x < 0 || y < 0 || x == m || y == n || visited[x,y] || matrix[x][y] <= prev )
            return 0;
        
        var dirs = new []{new []{-1,0}, new []{1,0}, new []{0,-1}, new []{0,1}};
        var curr = length+1;
        visited[x,y] = true;
        foreach(var dir in dirs){
            var val = LongestIncreasingPath(matrix, x+dir[0], y+dir[1], visited, length+1, matrix[x][y]);
            curr = Math.Max(curr, val);
        }
        visited[x,y] = false;
        return curr;
    }
}