class Solution:
    def findLHS(self, nums: List[int]) -> int:
        freq = Counter(nums)
        ans = 0
        for num in freq:
            if num+1 in freq:
                ans = max(ans, freq[num] + freq[num+1])

        return ans