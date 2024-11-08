# the trick is that - the max xor value for array will always be 2^maximumBit - 1
# so k will be anything that makes the total xor = 2^maximumBit - 1
class Solution:
    def getMaximumXor(self, nums: List[int], maximumBit: int) -> List[int]:
        n = len(nums)
        allxor, maxxor = 0, (1 << maximumBit) - 1
        for num in nums:
            allxor ^= num

        ans = [0] * n
        ans[0] = maxxor ^ allxor

        for i in range(1, n):
            ans[i] = ans[i-1] ^ nums[n-i]

        return ans