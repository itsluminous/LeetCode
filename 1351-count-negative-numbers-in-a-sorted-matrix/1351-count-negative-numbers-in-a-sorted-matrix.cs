// it is guaranteed that if col x in a row is k, then col x in row-1 will be >= k
// so we start from bottom row, left col and move right till we find negative
// once we find -ve, the row above will for sure not have a negative before this col idx
public class Solution {
    public int CountNegatives(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;

        // start from bottom left
        int r = m-1, c = 0, ans = 0;
        while(r >= 0 && c < n){
            if(grid[r][c] < 0){
                r--;
                ans += n - c;   // m - c negative in current row
            }
            else
                c++;
        }
        return ans;
    }
}