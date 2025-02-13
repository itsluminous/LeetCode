class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        op = 0
        heapify(nums)
        num1 = heappop(nums)
        
        while num1 < k:
            num2 = heappop(nums)
            heappush(nums, 2 * num1 + num2)
            num1 = heappop(nums)
            op += 1
        
        return op