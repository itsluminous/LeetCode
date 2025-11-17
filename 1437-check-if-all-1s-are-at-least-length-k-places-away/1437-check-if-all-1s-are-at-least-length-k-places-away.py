class Solution:
    def kLengthApart(self, nums: List[int], k: int) -> bool:
        prev = -k
        for i, num in enumerate(nums):
            if num == 0: continue
            if i - prev < k: return False
            prev = i+1
        return True