public class Solution {
    // treat 2d matrix as a big array of length m*n, then do binary search
    public bool SearchMatrix(int[][] matrix, int target) {
        int m=matrix.Length, n=matrix[0].Length;
        int l=0, r=m*n;
        while(l<r){
            int mid = (l+r)/2;
            int x=mid/n, y=mid%n;
            
            if(matrix[x][y] == target) return true;
            if(matrix[x][y] < target) l=mid+1;
            else r=mid;
        }
        return false;
    }
}