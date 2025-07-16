class Solution:
    def maximumLength(self, nums: List[int]) -> int:
        # we can have 3 types of subsequence
        # all odd, all even, alternating parity
        odd = even = alt = 0
        parity = (nums[0] & 1)
        
        for num in nums:
            if (num & 1) == 0: even += 1
            else: odd += 1

            if (num & 1) == parity:
                alt += 1
                parity = 1 - parity    # toggle

        return max(alt, odd, even)