class Solution:
    def divideArray(self, nums: List[int], k: int) -> List[List[int]]:
        nums.sort()
        
        n = len(nums)
        ansLen = n//3
        ans = []

        for i in range(0, ansLen):
            idx = i * 3
            if nums[idx+2] - nums[idx] > k: return []
            ans.append([nums[idx], nums[idx+1], nums[idx+2]])

        return ans