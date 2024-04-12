class Solution:
    def romanToInt(self, s: str) -> int:
        dict = {'I':1, 'V':5, 'X':10, 'L':50, 'C':100, 'D':500, 'M':1000}

        ans = 0
        for i in range(len(s) - 1):
            curr, next = s[i], s[i+1]
            ans += -dict[curr] if dict[curr] < dict[next] else dict[curr]

        return ans + dict[s[-1]]