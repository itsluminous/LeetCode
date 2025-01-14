class Solution:
    def findThePrefixCommonArray(self, A: List[int], B: List[int]) -> List[int]:
        n = len(A)
        count = [0] * (n+1)
        ans = [0] * n

        common = 0
        for i in range(n):
            count[A[i]] += 1
            if count[A[i]] == 2: common += 1

            count[B[i]] += 1
            if count[B[i]] == 2: common += 1

            ans[i] = common

        return ans