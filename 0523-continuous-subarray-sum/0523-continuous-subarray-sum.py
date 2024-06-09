# if any num is repeated while iterating, then it means that sum of nums in between is divisible by k
class Solution:
    def checkSubarraySum(self, nums: List[int], k: int) -> bool:
        n = len(nums)
        idxMap = {0 : -1}

        curr = 0
        for i, num in enumerate(nums):
            curr += num
            curr %= k

            if curr in idxMap:
                prev = idxMap[curr]
                if i - prev > 1:  return True
            else:
                idxMap[curr] = i

        return False