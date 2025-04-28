class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        count = total = 0
        l = 0
        for r in range(len(nums)):
            total += nums[r]
            # shift left pointer till a good subarray is found
            while l <= r and total * (r - l + 1) >= k:
                total -= nums[l]
                l += 1
            
            # between l & r, we have (r - l + 1) subarrays, because any smaller subarray is guarateed to be < k
            count += r - l + 1
        return count