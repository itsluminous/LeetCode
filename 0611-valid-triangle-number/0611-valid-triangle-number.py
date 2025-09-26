class Solution:
    def triangleNumber(self, nums: List[int]) -> int:
        n, count = len(nums), 0
        nums.sort()
        
        for k in range(n-1, 1, -1):
            i, j = 0, k - 1
            while i < j:
                # condition for a triangle is that nums[i] + nums[j] > nums[k]
                if nums[i] + nums[j] > nums[k]:
                    count += j - i
                    j -= 1
                else:
                    i += 1

        return count