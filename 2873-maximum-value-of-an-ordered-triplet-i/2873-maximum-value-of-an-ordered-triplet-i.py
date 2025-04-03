# O(n) - without using extra space
class Solution:
    def maximumTripletValue(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0

        largestOnLeft = nums[0]   # nums[i]
        biggestDiff = 0           # nums[i] - nums[j]
        for k in range(1, n):
            curr = nums[k]
            ans = max(ans, biggestDiff * curr)                    # (nums[i] - nums[j]) * nums[k]
            biggestDiff = max(biggestDiff, largestOnLeft - curr)  # in case of nums[j] = curr
            largestOnLeft = max(largestOnLeft, curr)              # in case of nums[i] = curr

        return ans

# Accepted - O(n) - using extra array
class SolutionArr:
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