class Solution {
    public int lenLongestFibSubseq(int[] arr) {
        int n = arr.length, maxLen = 0;
        var dp = new int[n][n]; // length of fibonacci ending with idx i, j

        for(var curr=2; curr<n; curr++){
            int left = 0, right = curr - 1;
            while(left < right){
                var sum = arr[left] + arr[right];
                if(sum == arr[curr]){
                    dp[right][curr] = 1 + dp[left][right];
                    maxLen = Math.max(maxLen, dp[right][curr]);
                    right--;
                    left++;
                }
                else if(sum < arr[curr])
                    left++;
                else
                    right--;
            }
        }

        return maxLen > 0 ? maxLen + 2 : 0; // +2 because we did not count first 2 numbers
    }
}