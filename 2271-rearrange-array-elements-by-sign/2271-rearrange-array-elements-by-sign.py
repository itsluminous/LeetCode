class Solution:
    def rearrangeArray(self, nums: List[int]) -> List[int]:
        result = [*nums]

        p, n = 0, 1
        for i, num in enumerate(nums):
            if num < 0:
                result[n] = num
                n += 2
            else:
                result[p] = num
                p += 2

        return result