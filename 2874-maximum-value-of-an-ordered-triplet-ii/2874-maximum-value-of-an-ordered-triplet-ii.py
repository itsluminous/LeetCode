class Solution:
    def maximumTripletValue(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0

        # find out largest no. on right of each index
        largestOnRight = [0] * n
        for i in range(n-2, -1, -1):
            largestOnRight[i] = max(largestOnRight[i+1], nums[i+1])

        # find out largest and smallest pair (like #121 : best time to buy & sell stock)
        largestOnLeft = nums[0]
        for i in range(1, n-1):
            curr = nums[i]
            val = (largestOnLeft - curr) * largestOnRight[i]

            ans = max(ans, val)
            largestOnLeft = max(largestOnLeft, curr)

        return ans