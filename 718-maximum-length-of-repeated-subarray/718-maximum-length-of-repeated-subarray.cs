public class Solution {
    public int FindLength(int[] nums1, int[] nums2) {
        int n = nums1.Length, m = nums2.Length, max = 0;
        var dp = new int[m+1];    // ideally pick m or n - whichever is small for low space complexity
        
        for(var i=0; i<n; i++){
            for(var j=m-1; j>=0; j--){
                if(nums1[i] != nums2[j]) dp[j+1] = 0;
                else dp[j+1] = dp[j] + 1;
                
                max = Math.Max(max, dp[j+1]);
            }
        }
        return max;
    }
}