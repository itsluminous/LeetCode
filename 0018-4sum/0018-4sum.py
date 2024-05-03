class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        self.ans = []
        nums.sort()
        self.fourSumRecursive(nums, target, 4, 0, [])
        return self.ans
    
    def fourSumRecursive(self, nums: List[int], target: int, k: int, idx: int, curr: List[int]):
        if idx+k > len(nums): return

        # need to reduce problem to two sum
        if k>2:
            for i in range(idx, len(nums)):
                if i > idx and nums[i] == nums[i-1]: continue;   # skip repeated numbers
                curr.append(nums[i])
                self.fourSumRecursive(nums, target-nums[i], k-1, i+1, curr)
                curr.pop()
        # two-sum code
        else:
            left, right = idx, len(nums)-1
            while left < right:
                currSum = nums[left] + nums[right]
                if currSum == target:
                    self.ans.append(curr[:] + [nums[left], nums[right]])
                    while left < right and nums[left] == nums[left + 1]: left += 1;     # skip repeated numbers
                    while left < right and nums[right] == nums[right - 1]: right -= 1;  # skip repeated numbers
                    left += 1
                    right -= 1
                elif currSum < target: left += 1
                else: right -= 1