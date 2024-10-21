class Solution:
    def maxUniqueSplit(self, s: str) -> int:
        self.count = 0
        self.split(s, set(), 0)
        return self.count

    def split(self, s, seen, start):
        if start == len(s):
            self.count = max(self.count, len(seen))
            return

        for end in range(start+1, len(s)+1):
            substr = s[start : end]
            if substr in seen: continue
            
            seen.add(substr)
            self.split(s, seen, end)
            seen.remove(substr)