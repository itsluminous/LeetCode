class Solution {
    public int numSubseq(int[] nums, int target) {
        var n = nums.length;
        var MOD = 1_000_000_007;
        Arrays.sort(nums);

        // calculate 2^x for each x from 0 to n
        var power = new int[n];
        power[0] = 1;
        for(var i=1; i<n; i++)
            power[i] = (power[i-1] * 2) % MOD;
        
        // sliding window
        int l = 0, r = n-1, ans = 0;
        while(l <= r){
            if(nums[l] + nums[r] > target)
                r--;
            else{
                // x indexes in between can be picked in 2^x ways, including 0 pick (combination formula)
                var numsInBetween = r - l;
                ans = (ans + power[numsInBetween]) % MOD;
                l++;
            }
        }

        return ans;
    }
}