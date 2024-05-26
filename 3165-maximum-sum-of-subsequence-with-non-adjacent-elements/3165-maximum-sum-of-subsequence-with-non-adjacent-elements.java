public class Solution {
    public int maximumSumSubsequence(int[] nums, int[][] queries) {
        var MOD = 1_000_000_007;
        var n = nums.length;
        long totalSum = 0;
        var dp_incl = new long[n+1];     // to track max sum till now when including
        var dp_excl = new long[n+1];     // to track max sum till now when including

        // fill dp
        long incll = 0, excll = 0;
        for(var i=0; i<n; i++){
            var num = nums[i];
            long newExcl = Math.max(incll, excll);
            incll = (excll + num) % MOD;
            excll = newExcl;

            dp_incl[i] = incll;
            dp_excl[i] = excll;
        }

        for (var query : queries) {
            int pos = query[0];
            int val = query[1];
            nums[pos] = val;

            long incl = 0, excl = 0;
            if(pos != 0){
                incl = dp_incl[pos-1];
                excl = dp_excl[pos-1];
            }

            for(var i=pos; i<n; i++){
                var num = nums[i];
                long newExcl = Math.max(incl, excl);
                incl = (excl + num) % MOD;
                excl = newExcl;

                dp_incl[i] = incl;
                dp_excl[i] = excl;
            }

            long maxSum = Math.max(incl, excl);
            totalSum = (totalSum + maxSum) % MOD;
        }

        return (int) totalSum;
    }
}
