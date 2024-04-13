public class Solution {
    public int OrderOfLargestPlusSign(int n, int[][] mines) {
        var maxOrder = 0;

        var isMine = new bool[n,n];
        foreach(var mine in mines)
            isMine[mine[0],mine[1]] = true;

        // store max possible 1s in any direction
        var dp = new int[n,n];
        for(var i=0; i<n; i++){
            // traverse from left to right
            var count=0;
            for(var j=0; j<n; j++){
                count = isMine[i,j] ? 0 : count+1;
                dp[i,j] = count;
            }

            // traverse from right to left
            count=0;
            for(var j=n-1; j>=0; j--){
                count = isMine[i,j] ? 0 : count+1;
                dp[i,j] = Math.Min(dp[i,j], count);
            }
        }

        for(var i=0; i<n; i++){
            // traverse from up to down
            var count=0;
            for(var j=0; j<n; j++){
                count = isMine[j,i] ? 0 : count+1;
                dp[j,i] = Math.Min(dp[j,i], count);
            }

            // traverse from down to up
            count=0;
            for(var j=n-1; j>=0; j--){
                count = isMine[j,i] ? 0 : count+1;
                dp[j,i] = Math.Min(dp[j,i], count);
                
                maxOrder = Math.Max(maxOrder, dp[j,i]);
            }
        }

        return maxOrder;
    }
}