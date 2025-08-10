// child at (0,0) has no other option but to cover diagonal
// child starting top right should not cross diagonal else it will need more steps than n-1
// child starting bottom left should not cross diagonal else it will need more steps than n-1
public class Solution {
    public int MaxCollectedFruits(int[][] fruits) {
        int n = fruits.Length, ans = 0;
        for(var i=0; i<n; i++) ans += fruits[i][i]; // fruits consumed by child at (0,0)
        ans += Traverse(fruits);    // fruits consumed by child at (0, n-1)
        SwapAcrossDiagonal(fruits); // swap bottom left with upper right so that same Traverse method can be used
        ans += Traverse(fruits);    // fruits consumed by child at (n-1, 0)
        return ans;
    }

    private int Traverse(int[][] fruits){
        var n = fruits.Length;
        // instead of creating n x n dp array, we just care about prev row
        int[] prev = new int[n], curr = new int[n];
        Array.Fill(prev, int.MinValue);
        prev[n-1] = fruits[0][n-1]; // we start from here, so we definitely have this fruit

        // i = how much we drift from last col
        for(var i=1; i<n-1; i++){
            Array.Fill(curr, int.MinValue);
            var startCol = Math.Max(n-1-i, i+1);    // we cannot drift more than mid col, else we need more steps than n-1
            for(var j=startCol; j<n; j++){
                var best = prev[j];
                if(j-1 >= 0) best = Math.Max(best, prev[j-1]);
                if(j+1 < n) best = Math.Max(best, prev[j+1]);
                curr[j] = best + fruits[i][j];
            }
            (prev, curr) = (curr, prev);
        }

        return prev[n-1];
    }

    private void SwapAcrossDiagonal(int[][] fruits){
        var n = fruits.Length;
        for(var i = 0; i < n; ++i)
            for(var j = 0; j < i; ++j)
                (fruits[j][i], fruits[i][j]) = (fruits[i][j], fruits[j][i]);
    }
}