class Solution:
    def isArraySpecial(self, nums: List[int], queries: List[List[int]]) -> List[bool]:
        n = len(queries)
        ans = [False]*n

        # calculate how many bad pairs we have seen till now
        bad = [0] * len(nums)
        j = 0
        for i in range(1, len(nums)):
            if (nums[i] & 1) == (nums[i-1] & 1):  j += 1
            bad[i] = j

        # for each query, if the count of bad pairs at start index is same as that at end index, then its special
        for i in range(n):
            start, end = queries[i][0], queries[i][1]
            if bad[start] == bad[end]: ans[i] = True

        return ans