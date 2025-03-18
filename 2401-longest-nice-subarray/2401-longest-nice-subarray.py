class Solution:
    def longestNiceSubarray(self, nums: List[int]) -> int:
        longest = mask = 0

        left = 0
        for right, num in enumerate(nums):
            # while even a single bit was already set, shift left window
            while (mask & num) != 0:
                mask ^= nums[left]
                left += 1
            
            mask |= num    # set bits from curr number in mask
            longest = max(longest, right - left + 1)

        return longest

# Accepted - original soln, one extra step
class SolutionOrig:
    def longestNiceSubarray(self, nums: List[int]) -> int:
        longest = mask = 0

        left = 0
        for right, num in enumerate(nums):
            curr = mask ^ num

            # while even a single bit was already set, shift left window
            while (curr & mask) != mask:
                mask ^= nums[left]
                curr = mask ^ num
                left += 1
            longest = max(longest, right - left + 1)
            mask ^= num    # set bits from curr number in mask

        return longest