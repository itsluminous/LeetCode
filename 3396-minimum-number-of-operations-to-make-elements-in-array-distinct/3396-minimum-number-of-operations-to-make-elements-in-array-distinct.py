# O(n) - reverse traversal
class Solution:
    def minimumOperations(self, nums: List[int]) -> int:
        freq = [0] * 101
        for i in range(len(nums)-1, -1, -1):
            num = nums[i]
            freq[num] += 1

            # when we find first duplicate, delete everything till this point
            if freq[num] == 2:
                return (i + 3) // 3
        return 0   # in case of no duplicates


# Accepted - O(n) - 2 pointer
class Solution2p:
    def minimumOperations(self, nums: List[int]) -> int:
        freq = [0] * 101
        ops = duplicates = 0    # duplicates = how many nums b/w l & r are duplicate

        l = 0
        for r in range(0, len(nums), 3):
            duplicates += self.countThree(nums, freq, r)        # add up freq of next 3 numbers
            while duplicates > 0:                               # till there are duplicates
                duplicates -= self.removeThree(nums, freq, l)   # remove first 3, and reduce freq
                ops += 1
                l += 3

        return ops

    def countThree(self, nums: List[int], freq: List[int], idx: int) -> int:
        duplicates = 0
        for i in range(idx, idx+3):
            if i >= len(nums): break
            num = nums[i]
            freq[num] += 1
            if freq[num] == 2: duplicates += 1
        return duplicates

    def removeThree(self, nums: List[int], freq: List[int], idx: int) -> int:
        removed = 0
        for i in range(idx, idx+3):
            if i >= len(nums): break
            num = nums[i]
            freq[num] -= 1
            if freq[num] == 1: removed += 1
        return removed