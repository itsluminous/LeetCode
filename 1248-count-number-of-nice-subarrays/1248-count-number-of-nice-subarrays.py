class Solution:
    def numberOfSubarrays(self, nums: List[int], k: int) -> int:
        prefixSum = {0 : 1}
        currSum = subarrays = 0
        for num in nums:
            currSum += (num % 2)
            if currSum - k in prefixSum:
                subarrays += prefixSum[currSum - k]
            prefixSum[currSum] = prefixSum.get(currSum, 0) + 1
        return subarrays