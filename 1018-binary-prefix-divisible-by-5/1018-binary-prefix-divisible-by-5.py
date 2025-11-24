class Solution:
    def prefixesDivBy5(self, nums: List[int]) -> List[bool]:
        ans = []
        rem = 0    # remainder
        for num in nums:
            rem <<= 1
            rem |= num
            rem %= 5
            ans.append(rem == 0)
        return ans