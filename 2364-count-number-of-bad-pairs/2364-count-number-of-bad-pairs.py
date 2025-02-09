class Solution:
    def countBadPairs(self, nums: List[int]) -> int:
        # count how many numbers differ from their index
        mismatch = defaultdict(int)  # key = diff, value = count
        numsCount = len(nums)

        for i in range(len(nums)):
            diff = nums[i] - i
            mismatch[diff] += 1
        
        # a set of numbers with the same diff will always make good pairs
        # so we can only pair them with any other number in the world
        count = 0
        for freq in mismatch.values():
            numsCount -= freq
            count += freq * numsCount
        
        return count