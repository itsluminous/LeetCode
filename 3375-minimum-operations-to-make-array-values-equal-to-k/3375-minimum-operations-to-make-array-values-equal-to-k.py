class Solution:
    def minOperations(self, nums: List[int], k: int) -> int:
        uniq = set()
        for num in nums:
            if num < k: return -1           # not possible to convert it to k
            elif num > k: uniq.add(num)     # all bigger nums need to be converted

        return len(uniq)