class Solution:
    def maxSatisfaction(self, satisfaction: List[int]) -> int:
        satisfaction.sort()

        # maxSum = max sum attained till now, includeSum = sum of all nums included
        n, maxSum, includeSum = len(satisfaction), 0, 0
        for i in range(n-1, -1, -1):
            includeCurr = maxSum + includeSum + satisfaction[i]
            if includeCurr < maxSum: break
            maxSum = includeCurr
            includeSum += satisfaction[i]
        return maxSum