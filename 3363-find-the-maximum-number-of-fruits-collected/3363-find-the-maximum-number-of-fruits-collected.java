// child at (0,0) has no other option but to cover diagonal
// child starting top right should not cross diagonal else it will need more steps than n-1
// child starting bottom left should not cross diagonal else it will need more steps than n-1
class Solution {
    public int maxCollectedFruits(int[][] fruits) {
        int n = fruits.length, ans = 0;
        for(var i=0; i<n; i++) ans += fruits[i][i]; // fruits consumed by child at (0,0)
        ans += traverse(fruits);    // fruits consumed by child at (0, n-1)
        swapAcrossDiagonal(fruits); // swap bottom left with upper right so that same traverse method can be used
        ans += traverse(fruits);    // fruits consumed by child at (n-1, 0)
        return ans;
    }

    private int traverse(int[][] fruits){
        var n = fruits.length;
        // instead of creating n x n dp array, we just care about prev row
        int[] prev = new int[n], curr = new int[n];
        Arrays.fill(prev, Integer.MIN_VALUE);
        prev[n-1] = fruits[0][n-1]; // we start from here, so we definitely have this fruit

        // i = how much we drift from last col
        for(var i=1; i<n-1; i++){
            curr = new int[n];
            Arrays.fill(curr, Integer.MIN_VALUE);
            var startCol = Math.max(n-1-i, i+1);    // we cannot drift more than mid col, else we need more steps than n-1
            for(var j=startCol; j<n; j++){
                var best = prev[j];
                if(j-1 >= 0) best = Math.max(best, prev[j-1]);
                if(j+1 < n) best = Math.max(best, prev[j+1]);
                curr[j] = best + fruits[i][j];
            }
            prev = curr;
        }

        return prev[n-1];
    }

    private void swapAcrossDiagonal(int[][] fruits){
        var n = fruits.length;
        for(var i = 0; i < n; ++i)
            for(var j = 0; j < i; ++j){
                var temp = fruits[j][i];
                fruits[j][i] = fruits[i][j];
                fruits[i][j] = temp;
            }
    }
}