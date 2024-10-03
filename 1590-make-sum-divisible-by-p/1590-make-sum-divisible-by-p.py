# consider rem to be the sum of subarray that we want to remove
# the question is essentially find the shortest subarray with sum % p = rem 
class Solution:
    def minSubarray(self, nums: List[int], p: int) -> int:
        # find out what is the target sum of subarray that needs to be removed
        remainder = 0
        for num in nums:
            remainder = (num + remainder) % p
        if remainder == 0: return 0

        # map to track most recent index of when a remainder was seen
        # most recent because we want to minimize the size of array
        map = {}
        map[0] = -1

        n = len(nums)
        ans, preSum = n, 0
        for i, num in enumerate(nums):
            preSum = (preSum + num) % p    # we only care about remainder in prefixSum
            map[preSum] = i                # track most recent index of when have we seen this remainder

            key = (p + preSum - remainder) % p # if remainder is 10, and curr preSum is 4, we want to search for key=6
            if key in map:
                ans = min(ans, i - map[key])

        if ans < n: return ans
        return -1