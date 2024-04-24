class Solution:
    def tribonacci(self, n: int) -> int:
        t = [0, 1, 1]
        if(n < 3): return t[n]

        for _ in range(3, n+1):
            num = sum(t)
            t= [t[1], t[2], num]

        return t[2]