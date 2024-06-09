class Solution:
    def subarraysDivByK(self, nums: List[int], k: int) -> int:
        n, count = len(nums), 0
        freq = [0] * k
        freq[0] = 1

        curr = 0
        for num in nums:
            curr += num
            curr %= k
            if curr < 0: curr += k     # we need positive remainder

            count += freq[curr]
            freq[curr] += 1

        return count