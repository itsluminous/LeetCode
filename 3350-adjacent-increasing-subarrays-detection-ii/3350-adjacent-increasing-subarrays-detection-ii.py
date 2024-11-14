class Solution:
    def maxIncreasingSubarrays(self, nums: List[int]) -> int:
        k, prev, curr = 0, 0, 1    # prev is length of prev increasing subarray
        for i in range(1, len(nums)):
            if nums[i] > nums[i-1]:
                curr += 1
                continue
            k = self.getMaxLength(prev, curr, k)
            prev = curr
            curr = 1

        k = self.getMaxLength(prev, curr, k)
        return k

    def getMaxLength(self, prev, curr, k):
        kk = min(prev, curr) # length of k for prev & curr subarrays
        return max(k, kk, curr//2)