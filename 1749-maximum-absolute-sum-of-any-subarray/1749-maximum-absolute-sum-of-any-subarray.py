# if you plot prefix sum on a graph, then ans would be diff between highest and lowest point
class Solution:
    def maxAbsoluteSum(self, nums: List[int]) -> int:
        maxPos = maxNeg = preSum = 0

        for num in nums:
            preSum += num
            maxPos = max(maxPos, preSum)
            maxNeg = min(maxNeg, preSum)

        return maxPos - maxNeg

# Accepted - needs more comparisons
class SolutionBig:
    def maxAbsoluteSum(self, nums: List[int]) -> int:
        maxAns = currPos = currNeg = 0

        for num in nums:
            if num > 0:
                currNeg = min(currNeg + num, 0)
                currPos = max(currPos + num, num)
            else:
                currNeg = min(currNeg + num, num)
                currPos = max(currPos + num, 0)

            maxAns = max(maxAns, currPos, abs(currNeg))

        return maxAns