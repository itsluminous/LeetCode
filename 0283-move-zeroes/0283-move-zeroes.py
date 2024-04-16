class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        n, l = len(nums), 0

        for num in nums:
            if num != 0:
                nums[l] = num
                l += 1

        for i in range(l,n):
            nums[i] = 0