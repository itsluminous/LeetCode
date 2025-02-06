class Solution:
    def tupleSameProduct(self, nums: List[int]) -> int:
        n, count = len(nums), 0
        prod = {}

        for i in range(n):
            for j in range(i+1, n):
                p = nums[i] * nums[j]
                count += prod.get(p, 0)
                prod[p] = 1 + prod.get(p, 0)

        return 8 * count