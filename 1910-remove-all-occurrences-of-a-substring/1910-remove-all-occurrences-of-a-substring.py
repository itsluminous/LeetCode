# KMP - O(m + n)
class Solution:
    def removeOccurrences(self, s: str, part: str) -> str:
        sLen, pLen = len(s), len(part)
        lps = self.computeLPS(part)
        sb = []                             # to track seen chars in s
        matchingChars = [0] * (sLen + 1)    # count matching chars in part till any idx
        
        # look for match using KMP
        sIdx = pIdx = 0
        while sIdx < sLen:
            sb.append(s[sIdx])

            # if char in s & part match
            if s[sIdx] == part[pIdx]:
                pIdx += 1
                matchingChars[len(sb)] = pIdx

                # if complete part match is found, remove it from sb
                if pIdx == pLen:
                    sb[:] = sb[:-pLen]
                
                # point pIdx to next lookup in part string
                pIdx = matchingChars[len(sb)] if sb else 0
                sIdx += 1
            # backtrack in case curr char does not match
            elif pIdx != 0:
                pIdx = lps[pIdx - 1]
                sb[:] = sb[:-1]     # the curr char in s will be processed again
            else:
                # restart match from part[0]
                matchingChars[len(sb)] = 0
                sIdx += 1
        
        return ''.join(sb)
    
    def computeLPS(self, pattern: str) -> [int]:
        n = len(pattern)
        lps = [0] * n
        curr, length = 1, 0
        
        while curr < n:
            # if chars match, extend prefix length
            if pattern[curr] == pattern[length]:
                length += 1
                lps[curr] = length
                curr += 1
            # if chars don't match, backtrack one step
            elif length != 0:
                length = lps[length - 1]
            # if there is no backtracking possible, restart matching
            else:
                lps[curr] = 0
                curr += 1
        
        return lps


# Accepted - O(m * n)
class SolutionSimple:
    def removeOccurrences(self, s: str, part: str) -> str:
        pLen = len(part)
        sb = []
        
        for ch in s:
            sb.append(ch)
            if len(sb) >= pLen:
                temp = ''.join(sb[-pLen:])
                if temp == part:
                    sb[:] = sb[:-pLen]

        return ''.join(sb)