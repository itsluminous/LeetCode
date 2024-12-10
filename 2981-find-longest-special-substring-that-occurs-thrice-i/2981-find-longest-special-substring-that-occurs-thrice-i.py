class Solution:
    def maximumLength(self, s: str) -> int:
        count = {}  # frequency of each string of a len with a repeated char
        n, length = len(s), 0

        for start in range(n):
            ch = s[start]
            length = 0
            for end in range(start, n):
                if ch == s[end]:
                    length += 1
                    if (ch, length) in count:
                        count[(ch, length)] += 1
                    else :
                        count[(ch, length)] = 1
                else:
                    break

        ans = 0
        for (ch, ln), freq in count.items():
            if freq >= 3 and ln > ans:
                ans = ln

        return -1 if ans == 0 else ans