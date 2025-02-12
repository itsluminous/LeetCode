class Solution:
    def maximumSum(self, nums: List[int]) -> int:
        def numsum(num):
            s = 0
            while num > 0:
                s += num % 10
                num //= 10
            return s

        maxsum = -1
        sumMap = {}     # key = sum of digits, val = biggest no. for given digit sum

        for num in nums:
            s = numsum(num)
            if s in sumMap:
                maxsum = max(maxsum, num + sumMap[s])
                sumMap[s] = max(sumMap[s], num)
            else:
                sumMap[s] = num
        
        return maxsum
