class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        n, l, r = len(nums), 0, 0

        while r < n:
            if nums[r] != 0:
                nums[l] = nums[r]
                l += 1
            r += 1

        while l < n:
            nums[l] = 0
            l += 1