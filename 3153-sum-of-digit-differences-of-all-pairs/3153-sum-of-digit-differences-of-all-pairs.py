class Solution:
    def sumDigitDifferences(self, nums: List[int]) -> int:
        n = len(nums)
        d = len(str(nums[0]))
        totalDiff = 0

        for pos in range(d):
            # count freq of each digit in all nums
            freq = [0] * 10
            for i in range(n):
                digit = nums[i] % 10
                freq[digit] += 1
                nums[i] //= 10      # remove last digit which is already processed
            
            # count the other digits that need to be changed because of each digit
            for digit in range(10):
                count = freq[digit]
                totalDiff += count * (n - count) * 1  # Each pair contributes exactly 1 to the difference

        return totalDiff // 2   # we are doing double counting above, so div by 2