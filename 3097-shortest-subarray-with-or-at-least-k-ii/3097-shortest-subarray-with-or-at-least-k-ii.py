class Solution:
    def minimumSubarrayLength(self, nums: List[int], k: int) -> int:
        n, minLen, currOr = len(nums), len(nums)+1, 0
        bitCount = [0] * 32

        l = 0
        for r in range(n):
            # base case
            if nums[r] >= k: return 1

            # update cumulative OR
            currOr = self.addNumToOr(nums[r], currOr, bitCount)
            
            # shift left pointer till OR stops matching
            while currOr >= k:
                minLen = min(minLen, r - l + 1)
                currOr = self.removeNumFromOr(nums[l], currOr, bitCount)
                l += 1

        if minLen == n+1: return -1
        return minLen

    def removeNumFromOr(self, num, currOr, bitCount):
        for b in range(32):
            if num == 0: break
            bitCount[b] -= num & 1
            num >>= 1

            if bitCount[b] == 0:
                currOr &= (~(1 << b))

        return currOr

    def addNumToOr(self, num, currOr, bitCount):
        currOr |= num
        for b in range(32):
            if num == 0: break
            bitCount[b] += num & 1
            num >>= 1

        return currOr