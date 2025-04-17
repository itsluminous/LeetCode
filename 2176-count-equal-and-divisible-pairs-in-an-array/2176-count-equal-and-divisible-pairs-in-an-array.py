# Brute Force
class Solution:
    def countPairs(self, nums: List[int], k: int) -> int:
        count = 0
        for i in range(len(nums)):
            for j in range(i+1, len(nums)):
                if nums[i] == nums[j] and i*j % k == 0:
                    count += 1

        return count

# Accepted - first group same numbers together, then check divisibility
class SolutionMap:
    def countPairs(self, nums: List[int], k: int) -> int:
        sameIdx = [[] for _ in range(101)]
        for i,num in enumerate(nums):
            sameIdx[num].append(i)

        count = 0
        for indexes in sameIdx:
            if len(indexes) < 2: continue
            for i in range(len(indexes)):
                for j in range(i+1, len(indexes)):
                    if indexes[i] * indexes[j] % k == 0:
                        count += 1

        return count