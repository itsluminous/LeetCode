class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        left = right = 0
        seen = [False] * 201

        while right < len(nums):
            if not seen[nums[right] + 100]:
                nums[left] = nums[right]
                seen[nums[right] + 100] = True
                left += 1
            right += 1
        return left