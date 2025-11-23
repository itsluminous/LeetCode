class Solution:
    def maxSumDivThree(self, nums: List[int]) -> int:
        maxSum = [0, 0, 0]    # max sum for remainder 0, 1, 2
        for num in nums:
            for prevSum in maxSum[:]:
                rem = (prevSum + num) % 3
                maxSum[rem] = max(maxSum[rem], prevSum + num)
        return maxSum[0]   # max sum with no remainder