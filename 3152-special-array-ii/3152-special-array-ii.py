class Solution:
    def isArraySpecial(self, nums: List[int], queries: List[List[int]]) -> List[bool]:
        n = len(nums)
        
        # prefix array of how many have same parity till given idx
        pre = [0]*(n)
        for i in range(1, n):
            if (nums[i] & 1) == (nums[i-1] & 1):
                pre[i] = pre[i-1] + 1
            else:
                pre[i] = pre[i-1]

        # figure out ans based on prefix array
        ans = [False] * len(queries)
        for i, (start, end) in enumerate(queries):
            if pre[start] == pre[end]:
                ans[i] = True
        
        return ans

                