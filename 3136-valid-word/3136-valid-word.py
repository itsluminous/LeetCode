class Solution:
    def isValid(self, word: str) -> bool:
        if len(word) < 3: return False
        
        vowels = set('aeiouAEIOU')
        vowel = consonant = False

        for ch in word:
            if not (('0' <= ch <= '9') or ('A' <= ch <= 'Z') or ('a' <= ch <= 'z')): return False
            if ch in vowels: vowel = True
            elif ch > '9': consonant = True

        return vowel and consonant