class Solution:
    def sumZero(self, n: int) -> List[int]:
        ans = [0] * n
        idx, num = 0, 1
        
        # for odd length, we need extra 0 digit
        if (n & 1) == 1: idx += 1
        
        while idx < n:
            ans[idx] = -num
            ans[idx+1] = num
            idx += 2
            num += 1

        return ans