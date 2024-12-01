# prefixSum : track sum on left of zero and right if zero
class Solution:
    def countValidSelections(self, nums: List[int]) -> int:
        n = len(nums)
        leftSum, rightSum = [0] * n, [0] * n

        for i in range(1, n):
            leftSum[i] = leftSum[i-1] + nums[i-1]
            rightSum[n-i-1] = rightSum[n-i] + nums[n-i]

        ans = 0
        for i in range(n):
            if nums[i] != 0: continue
            diff = abs(leftSum[i] - rightSum[i])
            if diff == 0: ans += 2 # we can go in left & right dir both
            if diff == 1: ans += 1 # we can go only in one direction

        return ans