class Solution:
    def isZeroArray(self, nums: List[int], queries: List[List[int]]) -> bool:
        n = len(nums)
        sub = [0] * n   # to track which idx incr starts, and till what index

        for start, end in queries:
            sub[start] += 1
            if end+1 < n: sub[end+1] -= 1

        curr = 0
        for i in range(n):
            curr += sub[i]
            if nums[i] - curr > 0: return False

        return True