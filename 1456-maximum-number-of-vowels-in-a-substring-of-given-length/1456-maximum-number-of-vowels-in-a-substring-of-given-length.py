class Solution:
    def maxVowels(self, s: str, k: int) -> int:
        isVowel = [False]*26
        a_val = ord('a')
        isVowel[0] = isVowel[ord('e')-a_val] = isVowel[ord('i')-a_val] = isVowel[ord('o')-a_val] = isVowel[ord('u')-a_val] = True

        max_val = curr = 0
        for i, ch in enumerate(s):
            if isVowel[ord(ch)-a_val]: curr += 1
            if i >= k and isVowel[ord(s[i-k])-a_val]: curr -= 1
            max_val = max(max_val, curr)

        return max_val