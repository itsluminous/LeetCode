class Solution:
    def getSneakyNumbers(self, nums: List[int]) -> List[int]:
        ans = []

        for i in range(len(nums)):
            num = nums[i] - 1000 if nums[i] >= 1000 else nums[i]
            
            if nums[num] >= 1000:   # visited
                ans.append(num)
            else:
                nums[num] += 1000

        return ans