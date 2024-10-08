# the trick is that no. of swaps needed will always be no. of mismatches / 2
# https:#assets.leetcode.com/users/images/0731629f-ae07-4507-bfc4-a7b1bea289b6_1628395785.653253.png
class Solution:
    def minSwaps(self, s: str) -> int:
        mismatch = 0
        for ch in s:
            if ch == '[':
                mismatch += 1
            elif mismatch > 0:
                mismatch -= 1
        return (mismatch + 1) // 2