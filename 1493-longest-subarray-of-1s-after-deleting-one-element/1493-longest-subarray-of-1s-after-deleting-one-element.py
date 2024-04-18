class Solution:
    def longestSubarray(self, nums: List[int]) -> int:
        n, k, l, r, z, max_val = len(nums), 1, 0, 0, 0, 0
        while r<n:
            if nums[r] == 1:
                r += 1
                continue
            if nums[r] == 0 and z < k:
                z += 1
                r += 1
                continue
            # if nums[r] == 0 and z == k
            max_val = max(max_val, r-l-k)
            if nums[l] == 0 and z != 0: z -= 1
            l += 1
            if r < l: r += 1
        return max(max_val, (r-l-k))