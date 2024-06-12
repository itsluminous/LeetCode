class Solution:
    def sortColors(self, nums: List[int]) -> None:
        freq = [0] * 3
        for num in nums: freq[num] += 1

        idx = 0
        for num in range(3):
            for i in range(freq[num]):
                nums[idx] = num
                idx += 1
        