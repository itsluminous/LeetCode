class Solution:
    def smallestNumber(self, n: int) -> int:
        ans = 1
        while ans < n:
            ans = 1 + ans*2
        return ans