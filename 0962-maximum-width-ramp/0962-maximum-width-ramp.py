class Solution:
    def maxWidthRamp(self, nums: List[int]) -> int:
        n = len(nums)

        # populate the rightMax array, which will contain biggest no. on right side
        rightMax = [0] * n
        rightMax[n-1] = nums[n-1]
        for i in range(n-2, -1, -1):
            rightMax[i] = max(rightMax[i+1], nums[i])
        
        left = right = maxWidth = 0
        while right < n:
            # move left pointer if needed
            while left < right and nums[left] > rightMax[right]:
                left += 1
            maxWidth = max(maxWidth, right - left)
            right += 1

        return maxWidth