class Solution:
    def specialArray(self, nums: List[int]) -> int:
        n = len(nums)

        # bucket sort - count[i] means how many numbers are equal to i
        count = [0] * (n+1)
        for num in nums:
            if num > n: count[n] += 1
            else: count[num] += 1

        # from reverse, find the first idx where nums >= idx are idx
        greaterThanCurr = 0
        for idx in range(n, 0, -1):
            greaterThanCurr += count[idx]
            if greaterThanCurr == idx: return idx

        return -1