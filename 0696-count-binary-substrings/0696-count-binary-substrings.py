class Solution:
    def countBinarySubstrings(self, s: str) -> int:
        ans = z = o = 0
        prev = s[0]

        for curr in s:
            if curr == prev:
                if curr == '0': z += 1
                else: o += 1
            else:
                ans += min(z, o)
                if curr == '0': z = 1
                else: o = 1
                prev = curr

        ans += min(z, o)
        return ans