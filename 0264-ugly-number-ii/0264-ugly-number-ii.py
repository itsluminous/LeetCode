class Solution:
    def nthUglyNumber(self, n: int) -> int:
        ugly = [1] * n
        idx2 = idx3 = idx5 = 0
        mul2, mul3, mul5 = 2, 3, 5   # multiple of 2, 3, 5

        for i in range(1, n):
            minNum = min(mul2, mul3, mul5)
            ugly[i] = minNum

            if minNum == mul2:
                idx2 += 1
                mul2 = 2 * ugly[idx2]
            if minNum == mul3:
                idx3 += 1
                mul3 = 3 * ugly[idx3]
            if minNum == mul5:
                idx5 += 1
                mul5 = 5 * ugly[idx5]

        return ugly[n-1]