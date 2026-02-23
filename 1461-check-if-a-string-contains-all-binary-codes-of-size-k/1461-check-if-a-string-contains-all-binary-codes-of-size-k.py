class Solution:
    def hasAllCodes(self, s: str, k: int) -> bool:
        strs = set()
        for i in range(len(s) - k + 1):
            strs.add(s[i:i+k])
        
        expectedCount = (1 << k);   # this is max number possible with k binary digits
        actualCount = len(strs)

        # if total items in set is not same as max possible, then some numbers are missing
        return expectedCount == actualCount