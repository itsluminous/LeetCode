class Solution:
    def canPartitionKSubsets(self, nums: List[int], k: int) -> bool:
        if len(nums) < k: return False

        totalSum = sum(nums)
        if totalSum % k != 0: return False  # it can never be divided in 4

        # sort array in descending
        nums.sort(reverse=True)

        sideSum = totalSum / k              # allowed sum of each side
        if nums[0] > sideSum: return False  # one stick cannot exceed sideSum

        # try to split the nums into k groups
        self.seen = [set() for _ in range(len(nums) + 1)]
        return self.dfs(nums, k, sideSum, 0, 0, 0)

    def dfs(self, nums: List[int], k: int, targetSum: int, visited: int, currSum: int, idx: int):
        # if we have already seen this mask, then useless
        if visited in self.seen[k]: return False
        self.seen[k].add(visited)

        # all pending nums can be put in one side, if we need only one side
        if k == 1: return True 
        
        # if current side is done, then look for other sides
        if currSum == targetSum: return self.dfs(nums, k-1, targetSum, visited, 0, 0)

        # try to fit every remaining matchstick one by one to match targetSum
        for i in range(len(nums)):
            mask = 1 << i
            if (visited & mask) == mask or (currSum + nums[i]) > targetSum: continue
            visited |= mask
            if self.dfs(nums, k, targetSum, visited, currSum + nums[i], idx+1): return True
            visited ^= mask

        # not possible to make square with current setup
        return False