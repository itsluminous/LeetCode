class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        n = len(nums)
        result = [1]*n

        # calculate all products from left
        prod = 1
        for i in range(1, n):
            prod *= nums[i-1]
            result[i] = prod

        # calculate all products from right
        prod = 1
        for i in range(n-2, -1, -1):
            prod *= nums[i+1]
            result[i] *= prod

        return result