class Solution:
    def smallestDistancePair(self, nums: List[int], k: int) -> int:
        n = len(nums)
        nums.sort()

        # max distance b/w two nums is dist between largest & smallest
        low, high = 0, nums[n-1] - nums[0]
        
        # binary search to find the distance at kth index
        while low < high:
            mid = low + (high - low) // 2
            count = self.countPairsWithMaxDistance(nums, mid)

            if count < k: low = mid+1
            else: high = mid

        return low
    
    def countPairsWithMaxDistance(self, nums: List[int], k: int) -> int:
        n, count = len(nums), 0

        left = 0
        for right in range(n):
            # increment left till distance > k
            while nums[right] - nums[left] > k: left += 1
            count += (right - left)

        return count