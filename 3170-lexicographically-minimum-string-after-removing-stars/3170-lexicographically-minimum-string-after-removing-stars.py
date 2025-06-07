class Solution:
    def clearStars(self, s: str) -> str:
        n = len(s)
        removed = [False] * n  # to track which indexes are removed from final ans

        # pos will track which all indexes have characters 'a' to 'z'
        pos = [[] for _ in range(26)]

        for i in range(n):
            if s[i] != '*':
                pos[ord(s[i]) - ord('a')].append(i)  # found non '*' char, so save its pos
            else:
                removed[i] = True  # mark '*' as removed
                # find out the smallest character that can be removed
                for ch in range(ord('a'), ord('z') + 1):
                    if not pos[ch - ord('a')]: continue
                    idx = pos[ch - ord('a')].pop()  # remove max idx of smallest character
                    removed[idx] = True
                    break

        # any idx not marked for removal will be in ans
        ans = []
        for i in range(n):
            if not removed[i]: ans.append(s[i])

        return ''.join(ans)