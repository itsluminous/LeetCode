class Solution:
    def longestConsecutive(self, nums: List[int]) -> int:
        nums_set = set(nums)

        ans = 0
        for num in nums_set:
            if num-1 in nums_set: continue;   # already processed, or will be eventually

            count, curr_num = 1, num
            while curr_num+1 in nums_set:
                count, curr_num = count+1, curr_num+1
            ans = max(ans, count)

        return ans