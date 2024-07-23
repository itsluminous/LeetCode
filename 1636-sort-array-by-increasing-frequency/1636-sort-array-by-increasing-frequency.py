class Solution:
    def frequencySort(self, nums: List[int]) -> List[int]:
        # count freq of each number
        freq = Counter(nums)

        # sort the numbers based on logic
        nums.sort(key = lambda num: (freq[num], -num))

        # return the sorted nums
        return nums