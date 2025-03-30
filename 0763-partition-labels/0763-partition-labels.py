class Solution:
    def partitionLabels(self, s: str) -> List[int]:
        n = len(s)

        # store last occurence of a character
        last = [0] * 26
        for i, ch in enumerate(s):
            idx = ord(ch) - ord('a')
            last[idx] = i

        ans = []
        start = end = 0
        for i, ch in enumerate(s):
            idx = ord(ch) - ord('a')
            if end < i:
                ans.append(end - start + 1)
                start = i
            end = max(end, last[idx])

        ans.append(end - start + 1)
        return ans