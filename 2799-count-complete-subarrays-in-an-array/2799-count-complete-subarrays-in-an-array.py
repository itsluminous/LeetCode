class Solution:
    def countCompleteSubarrays(self, nums: List[int]) -> int:
        n, ans = len(nums), 0

        # count unique elements in the whole array
        uniq_count = len(set(nums))

        # sliding window to find complete subarrays
        freq = defaultdict(int)
        l = 0
        for r in range(n):
            freq[nums[r]] += 1
            while len(freq) == uniq_count:
                ans += n - r  # adding any element on right will not change curr uniq count

                # move left pointer
                freq[nums[l]] -= 1
                if freq[nums[l]] == 0:
                    del freq[nums[l]]
                l += 1

        return ans