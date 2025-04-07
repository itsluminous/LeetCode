# 1D dp
class Solution:
    def canPartition(self, nums: List[int]) -> bool:
        n = len(nums)
        total = sum(nums)
        if (total & 1) == 1: return False  # odd can never be partitioned
        
        target = total//2
        dp = [False] * (target+1)   # tells if sum "s" is possible or not
        dp[0] = True                # its always possible to reach a sum of 0
        
        # find out all possible sums from the nums array
        for num in nums:
            for s in range(target, -1, -1):
                if s >= num:
                    dp[s] = dp[s] or dp[s-num]
        
        return dp[target] # check if "sum" is possible

# Accepted - 2D dp
class Solution2d:
    def canPartition(self, nums: List[int]) -> bool:
        total = sum(nums)
        if (total & 1) == 1: return False  # odd can never be partitioned

        target = total//2
        self.dp = [[0] * (target + 1) for _ in range(len(nums))] # for each idx, 0 = unknown, 1 = can make, 2 = can't
        return self.canMake(nums, 0, target)

    def canMake(self, nums, idx, target):
        if target == 0: return True
        if target < 0: return False
        if idx == len(nums): return False
        if self.dp[idx][target] > 0: return self.dp[idx][target] == 1

        # don't include curr idx
        if self.canMake(nums, idx+1, target):
            self.dp[idx][target] = 1
            return True
        
        if self.canMake(nums, idx+1, target - nums[idx]):
            self.dp[idx][target] = 1
        else:
            self.dp[idx][target] = 2
        
        return self.dp[idx][target] == 1