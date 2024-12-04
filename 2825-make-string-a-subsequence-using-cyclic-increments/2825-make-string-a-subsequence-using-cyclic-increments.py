class Solution:
    def canMakeSubsequence(self, str1: str, str2: str) -> bool:
        len1, len2 = len(str1), len(str2)
        idx1 = idx2 = 0
        if len1 < len2: return False

        while idx1 < len1 and idx2 < len2:
            if self.charMatch(str1[idx1], str2[idx2]):
                idx2 += 1
            idx1 += 1

        return idx2 == len2

    def charMatch(self, ch1, ch2) -> bool:
        if ch1 == ch2: return True
        if ch1 == 'z' and ch2 == 'a': return True
        return 1 + ord(ch1) == ord(ch2)