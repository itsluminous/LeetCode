class Solution:
    def maxDistinctElements(self, nums: List[int], k: int) -> int:
        nums.sort()
        ans = 0
        prev = -math.inf

        for num in nums:
            curr = min(max(prev + 1, num - k), num + k)
            if curr > prev:
                ans += 1
                prev = curr
        return ans