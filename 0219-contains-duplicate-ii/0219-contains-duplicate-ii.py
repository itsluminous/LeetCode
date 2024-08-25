class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        seen = set()
        for i, num in enumerate(nums):
            if num in seen: return True
            seen.add(num)
            if i >= k: seen.remove(nums[i-k])

        return False