class Solution:
    def checkInclusion(self, s1: str, s2: str) -> bool:
        freq = [0]*26
        for ch in s1:
            freq[ord(ch) - ord('a')] += 1
        
        curr = freq[:]
        l = r = count = 0
        while r < len(s2):
            rpos = ord(s2[r]) - ord('a')
            # if this char does not exist in s1
            if freq[rpos] == 0:
                l = r = r+1
                count = 0
                curr = freq[:]
            else:
                # if this char is breaking permutation
                while curr[rpos] == 0:
                    lpos = ord(s2[l]) - ord('a')
                    curr[lpos] += 1
                    count -=1
                    l += 1

                # include curr char in permutation
                curr[rpos] -=1
                count += 1
                r += 1

            # did we find permutation?
            if count == len(s1): return True
        return False