class Solution:
    def rob(self, nums: List[int]) -> int:
        notRob, rob = 0, nums[0]
        for i in range(1, len(nums)):
            notRobCurr = max(notRob, rob)
            rob = notRob + nums[i]
            notRob = notRobCurr

        return max(rob, notRob)