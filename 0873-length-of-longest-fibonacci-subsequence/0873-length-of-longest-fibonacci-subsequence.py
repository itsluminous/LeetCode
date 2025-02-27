class Solution:
    def lenLongestFibSubseq(self, arr: List[int]) -> int:
        n, maxLen = len(arr), 0
        dp = [[2] * n for _ in range(n)]

        for curr in range(2, n):
            left, right = 0, curr - 1
            while left < right:
                pairSum = arr[left] + arr[right]
                if pairSum == arr[curr]:
                    dp[right][curr] = 1 + dp[left][right]
                    maxLen = max(maxLen, dp[right][curr])
                    right -= 1
                    left += 1
                elif pairSum < arr[curr]:
                    left += 1
                else:
                    right -= 1

        return maxLen if maxLen > 2 else 0