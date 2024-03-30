class Solution:
    def subarraysWithKDistinct(self, nums: List[int], k: int) -> int:
        return self.subarraysWithKOrLessDistinct(nums, k) - self.subarraysWithKOrLessDistinct(nums, k-1)

    def subarraysWithKOrLessDistinct(self, nums: List[int], k: int) -> int:
        freq = defaultdict(int);
        count = 0
        l = 0

        for r in range(len(nums)):
            freq[nums[r]] += 1;

            while len(freq) > k:
                freq[nums[l]] -= 1
                if freq[nums[l]] == 0:
                    del freq[nums[l]]
                l += 1

            count += (r-l+1)
        
        return count