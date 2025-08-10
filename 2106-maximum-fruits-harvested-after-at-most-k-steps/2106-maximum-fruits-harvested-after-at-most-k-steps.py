class Solution:
    def maxTotalFruits(self, fruits: List[List[int]], startPos: int, k: int) -> int:
        def valid(left: int, right: int) -> bool:
            # optimal path will be either left only, or right only, or just one u-turn
            stepsForFruitsInMid = fruits[right][0] - fruits[left][0]
            stepsForLeftThenRight = abs(startPos - fruits[left][0])
            stepsForRightThenLeft = abs(startPos - fruits[right][0])
            stepsForUturn = min(stepsForLeftThenRight, stepsForRightThenLeft)
            return stepsForUturn + stepsForFruitsInMid <= k

        n, ans = len(fruits), 0
        left = currSum = 0

        # slide right window
        for right in range(n):
            currSum += fruits[right][1]
            # slide left window if it is outside k range
            while left <= right and not valid(left, right):
                currSum -= fruits[left][1]
                left += 1
            ans = max(ans, currSum)
        return ans