class Solution:
    def findKthBit(self, n: int, k: int) -> str:
        # base case
        if n == 1: return '0'

        # length of the final string possible (2^n)
        length = 1 << n

        # exact middle of str will always be 1
        if k == length//2: return '1'  
        # if result is in left half
        if k < length//2: return self.findKthBit(n-1, k) 
        # kth bit in right half is same as inverse of length-k bit in left
        ans = self.findKthBit(n-1, length-k)
        return '1' if ans == '0' else '0'