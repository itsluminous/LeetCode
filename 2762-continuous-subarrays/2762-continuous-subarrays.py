class Solution:
    def continuousSubarrays(self, nums: List[int]) -> int:
        left = right = 0
        windowLen = count = 0
        minVal = maxVal = nums[0]

        for right in range(len(nums)):
            maxVal = max(maxVal, nums[right])
            minVal = min(minVal, nums[right])
            if maxVal - minVal <= 2: continue

            # add curr window permutations
            windowLen = right - left
            count += (windowLen * (windowLen + 1)) // 2

            # start new window
            left = right
            maxVal = minVal = nums[right]

            # move left till diff <= 2
            while left > 0 and abs(nums[right] - nums[left-1]) <= 2:
                left -= 1
                maxVal = max(maxVal, nums[left])
                minVal = min(minVal, nums[left])

            # remove anything that was added as part of prev window
            windowLen = right - left
            count -= (windowLen * (windowLen + 1)) // 2

        # add count of final window
        windowLen = right - left + 1
        count += (windowLen * (windowLen + 1)) // 2

        return count