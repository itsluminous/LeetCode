class Solution:
    def countOfSubstrings(self, word: str, k: int) -> int:
        n = len(word)
        vowels = {'a': 0, 'e': 0, 'i': 0, 'o': 0, 'u': 0}
        v = c = ans = 0   # count of distinct vowels and count of consonants and ans

        # find pos of first consonant on right of each index
        nextConsonant = [0] * n
        lastConsonant = n
        for i in range(n-1, -1, -1):
            nextConsonant[i] = lastConsonant
            if not self.is_vowel(word[i]): lastConsonant = i

        l = 0
        for r in range(0, n):
            # expand window on right
            ch = word[r]
            if self.is_vowel(ch):
                vowels[ch] += 1
                if vowels[ch] == 1: v += 1    # found new vowel
            else: c += 1

            # shrink window on left
            while c > k:
                ch1 = word[l]
                if self.is_vowel(ch1):
                    vowels[ch1] -= 1
                    if vowels[ch1] == 0: v -= 1    # lost a vowel
                else: c -= 1
                l += 1

            # count matching strings
            while v == 5 and c == k:
                ans += nextConsonant[r] - r
                ch1 = word[l]
                if self.is_vowel(ch1):
                    vowels[ch1] -= 1
                    if vowels[ch1] == 0: v -= 1    # lost a vowel
                else: c -= 1
                l += 1

        return ans

    def is_vowel(self, ch: str) -> bool:
        return ch in {'a', 'e', 'i', 'o', 'u'}