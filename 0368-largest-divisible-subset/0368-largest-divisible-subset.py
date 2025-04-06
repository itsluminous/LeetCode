# Similar solution as Longest Increasing Subsequence
class Solution:
    def largestDivisibleSubset(self, nums: List[int]) -> List[int]:
        n = len(nums)
        lis = [0] * n   # longest subset count till curr idx
        prev = [0] * n  # prev index included in lis ending at index i

        maxLen, maxIdx = 0, -1  # track max length of subset and index where it ends
        nums.sort()             # sort so that all divisors are on left side

        for i in range(n):
            lis[i] = 1     # assume only curr idx is in lis
            prev[i] = -1   # no prev element in lis

            for j in range(i-1, -1, -1):
                if nums[i] % nums[j] == 0 and lis[j] + 1 > lis[i]:
                    lis[i] = lis[j] + 1
                    prev[i] = j

            if maxLen < lis[i]:
                maxLen = lis[i]
                maxIdx = i

        # construct answer by backtracking from maxIdx
        longestSet = []
        while maxIdx != -1:
            longestSet.append(nums[maxIdx])
            maxIdx = prev[maxIdx]

        return longestSet