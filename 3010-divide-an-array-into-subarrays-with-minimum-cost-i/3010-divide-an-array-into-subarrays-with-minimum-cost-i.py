class Solution:
    def minimumCost(self, nums: List[int]) -> int:
        small1 = small2 = 51

        for i in range(1, len(nums)):
            if nums[i] <= small1:
                small2 = small1
                small1 = nums[i]
            elif nums[i] < small2:
                small2 = nums[i]

        return nums[0] + small1 + small2