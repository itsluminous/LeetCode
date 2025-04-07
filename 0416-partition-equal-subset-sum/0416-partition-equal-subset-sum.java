// 1D dp
public class Solution {
    public boolean canPartition(int[] nums) {
        var n = nums.length;
        var total = Arrays.stream(nums).sum();
        if((total & 1) == 1) return false;  // odd can never be partitioned
        
        var target = total/2;
        var dp = new boolean[target+1]; // tells if sum "s" is possible or not
        dp[0] = true;                   // its always possible to reach a sum of 0
        
        // find out all possible sums from the nums array
        for(var num : nums)
            for(var s=target; s>0; s--)
                if(s >= num)
                    dp[s] = dp[s] || dp[s-num];
        
        return dp[target]; // check if "sum" is possible
    }
}

// Accepted - 2D dp
class Solution2d {
    int[][] dp;

    public boolean canPartition(int[] nums) {
        var total = Arrays.stream(nums).sum();
        if((total & 1) == 1) return false;  // odd can never be partitioned

        var target = total/2;
        dp = new int[nums.length][1 + target]; // for each idx, 0 = unknown, 1 = can make, 2 = can't
        return canMake(nums, 0, target);
    }

    private boolean canMake(int[] nums, int idx, int target){
        if(target == 0) return true;
        if(target < 0) return false;
        if(idx == nums.length) return false;
        if(dp[idx][target] > 0) return dp[idx][target] == 1;

        // don't include curr idx
        if(canMake(nums, idx+1, target)) {
            dp[idx][target] = 1;
            return true;
        }
        
        if(canMake(nums, idx+1, target - nums[idx]))
            dp[idx][target] = 1;
        else
            dp[idx][target] = 2;
        
        return dp[idx][target] == 1;
    }
}