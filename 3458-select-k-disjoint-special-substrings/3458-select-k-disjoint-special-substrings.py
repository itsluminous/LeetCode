class Solution:
    def maxSubstringLength(self, s: str, k: int) -> bool:
        if k == 0: return True
        n = len(s)
        
        # find out first and last occurrences of each char
        first, last = [n]*26, [0]*26

        for i in range(n):
            idx = ord(s[i]) - ord('a')
            first[idx] = min(first[idx], i)
            last[idx] = max(last[idx], i)

        # capture start & end of all substrings that satisfy condition
        segments = []
        for start in range(n):
            # get the first & last occurence of curr char
            begin, end = first[ord(s[start]) - ord('a')], last[ord(s[start]) - ord('a')]

            # if curr char exists before the substring start, then it is invalid
            if begin < start: continue

            valid = True
            for curr in range(begin, end):
                if first[ord(s[curr]) - ord('a')] < begin:
                    valid = False
                    break
                end = max(end, last[ord(s[curr]) - ord('a')])

            # if this substring is not full string, then it is valid
            if valid and not (begin == 0 and end == n-1):
                segments.append([begin, end])

        # count non-overlapping substring segments
        count, lastIdx = 0, -1
        segments.sort(key=lambda seg: seg[1])   # sort based on end index

        for seg in segments:
            if seg[0] <= lastIdx: continue # overlapping
            lastIdx = seg[1]
            count += 1

        return count >= k