class Solution:
    def sortVowels(self, s: str) -> str:
        chars = list(s)
        all_vowels = set('aeiouAEIOU')

        # find all vowels and sort them
        vowels = [ch for ch in chars if ch in all_vowels]
        vowels.sort()

        # replaces vowels in string with sorted vowels
        idx = 0
        for i in range(len(chars)):
            if chars[i] in all_vowels:
                chars[i] = vowels[idx]
                idx += 1

        # build updated string and return
        ans = ''.join(chars)
        return ans
