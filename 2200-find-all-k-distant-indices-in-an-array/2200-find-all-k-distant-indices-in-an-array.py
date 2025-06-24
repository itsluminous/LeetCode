class Solution:
    def findKDistantIndices(self, nums: List[int], key: int, k: int) -> List[int]:
        n = len(nums)
        keyIndices = [i for i, num in enumerate(nums) if num == key]
        
        ans = []
        ki = i = 0
        while i < n and ki < len(keyIndices):
            # if the key is outside k range, look for next key
            if keyIndices[ki] < i and i - keyIndices[ki] > k:
                ki += 1
                continue
            # if the key is in k range, add curr idx to ans
            if keyIndices[ki] - i <= k:
                ans.append(i)
            i += 1

        return ans