class Solution:
    def decrypt(self, code: List[int], k: int) -> List[int]:
        n = len(code)
        ans = [0] * n
        if k == 0: return ans

        sum, l, r = 0, 1, k
        if k < 0:
            k = -k
            l = n - k  # l is now actually end of array
            r = n - 1  # r is start of array
        
        for i in range(l, r+1): sum += code[i]

        for i in range(n):
            ans[i] = sum
            sum -= code[l]
            l = (l + 1) % n
            r = (r + 1) % n
            sum += code[r]

        return ans