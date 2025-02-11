class Solution:
    def subarraySum(self, nums: List[int], k: int) -> int:
        preMap = {}
        preMap[0] = 1
        
        count = preSum = 0
        for num in nums:
            preSum += num
            count += preMap.get(preSum - k, 0)
            preMap[preSum] = 1 + preMap.get(preSum, 0)
        
        return count