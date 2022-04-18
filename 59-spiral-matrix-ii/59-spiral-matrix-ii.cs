public class Solution {
    public int[][] GenerateMatrix(int n) {
        var mat = new int[n][];
        for(var m=0; m<n; m++) mat[m] = new int[n];
        
        var dir = new []{new []{0,1}, new []{1, 0}, new []{0, -1}, new []{-1, 0}};
        int d=0, i=0, j=0, num=1;
        
        while(num <= n*n){
            mat[i][j] = num++;
            int r = Math.Abs((i + dir[d][0]) % n);
            int c = Math.Abs((j + dir[d][1]) % n);
            
            // change direction if next cell is non zero
            if (mat[r][c] != 0) d = (d + 1) % 4;
            
            i += dir[d][0];
            j += dir[d][1];
        }
        
        return mat;
    }
}