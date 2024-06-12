# using 3 pointers, one pass
# keep all 0 before low ptr, all 2 after high ptr, all 1 from low to high
# mid ptr will be used for traversing from 0 to n-1
class Solution:
    def sortColors(self, nums: List[int]) -> None:
        low, mid, high = 0, 0, len(nums) - 1

        while mid <= high:
            if nums[mid] == 0:
                nums[low], nums[mid] = nums[mid], nums[low]
                low += 1
                mid += 1
            elif nums[mid] == 1:
                mid += 1
            else:
                nums[high], nums[mid] = nums[mid], nums[high]
                high -= 1

# Accepted - using 2 pass
class Solution2pass:
    def sortColors(self, nums: List[int]) -> None:
        freq = [0] * 3
        for num in nums: freq[num] += 1

        idx = 0
        for num in range(3):
            for i in range(freq[num]):
                nums[idx] = num
                idx += 1
        