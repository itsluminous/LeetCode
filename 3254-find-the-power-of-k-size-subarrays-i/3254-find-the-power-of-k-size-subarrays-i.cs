public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        var n = nums.Length;
        var ans = new int[n-k+1];

        int l = 0, r = 1, wrongIdx = -1;
        while(r < k){
            if (nums[r] != 1 + nums[r-1])
                wrongIdx = r-1;
            r++;
        }
        if (wrongIdx < l) 
            ans[l] = nums[r-1];
        else
            ans[l] = -1;

        for(l=1; l < n-k+1; l++){
            if (nums[r] != 1 + nums[r-1])
                wrongIdx = r-1;
            r++;
            
            if (wrongIdx < l) 
                ans[l] = nums[r-1];
            else
                ans[l] = -1;
        }
            
        return ans;
    }
}