class Solution:
    def minimizeMax(self, nums: List[int], p: int) -> int:
        if p == 0: return 0
        
        nums.sort()
        n = len(nums)
        l, r = 0, nums[-1] - nums[0]

        while l < r:
            mid = l + (r - l) // 2
            if self.has_pairs(nums, p, mid): r = mid
            else: l = mid + 1
        return l

    def has_pairs(self, nums: List[int], p: int, max_diff: int):
        count = i = 0
        while i < len(nums) - 1:
            if nums[i + 1] - nums[i] <= max_diff:
                count += 1
                i += 2  # Skip next element as it's included in the current pair
                if count >= p: return True
            else:
                i += 1
        return False
