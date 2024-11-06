class Solution:
    def canSortArray(self, nums: List[int]) -> bool:
        prevHigh, currLow, currHigh = 0, nums[0], nums[0]
        for i in range(1, len(nums)):
            # if same segment
            if nums[i].bit_count() == nums[i-1].bit_count():
                currLow = min(currLow, nums[i])
                currHigh = max(currHigh, nums[i])
            elif currLow < prevHigh:
                return False
            else:
                prevHigh = currHigh
                currHigh = currLow = nums[i]

        return currLow >= prevHigh