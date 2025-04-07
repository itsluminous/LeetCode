// 1D dp
public class Solution {
    public bool CanPartition(int[] nums) {
        var n = nums.Length;
        var total = nums.Sum();
        if((total & 1) == 1) return false;  // odd can never be partitioned
        
        var target = total/2;
        var dp = new bool[target+1]; // tells if sum "s" is possible or not
        dp[0] = true;                   // its always possible to reach a sum of 0
        
        // find out all possible sums from the nums array
        foreach(var num in nums)
            for(var s=target; s>0; s--)
                if(s >= num)
                    dp[s] = dp[s] || dp[s-num];
        
        return dp[target]; // check if "sum" is possible
    }
}

// Accepted - 2D dp
public class Solution2d {
    int[,] dp;

    public bool CanPartition(int[] nums) {
        var total = nums.Sum();
        if((total & 1) == 1) return false;  // odd can never be partitioned

        var target = total/2;
        dp = new int[nums.Length,1 + target]; // for each idx, 0 = unknown, 1 = can make, 2 = can't
        return CanMake(nums, 0, target);
    }

    private bool CanMake(int[] nums, int idx, int target){
        if(target == 0) return true;
        if(target < 0) return false;
        if(idx == nums.Length) return false;
        if(dp[idx,target] > 0) return dp[idx,target] == 1;

        // don't include curr idx
        if(CanMake(nums, idx+1, target)) {
            dp[idx,target] = 1;
            return true;
        }
        
        if(CanMake(nums, idx+1, target - nums[idx]))
            dp[idx,target] = 1;
        else
            dp[idx,target] = 2;
        
        return dp[idx,target] == 1;
    }
}