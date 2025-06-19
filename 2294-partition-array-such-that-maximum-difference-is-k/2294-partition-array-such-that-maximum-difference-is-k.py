class Solution:
    def partitionArray(self, nums: List[int], k: int) -> int:
        nums.sort()
        count = 1  # 1 = subsequence with all numbers

        smallest = nums[0]
        for num in nums:
            if num - smallest <= k: continue
            smallest = num
            count += 1    # start new subsequence

        return count