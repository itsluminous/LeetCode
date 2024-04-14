class Solution:
    def reverseVowels(self, s: str) -> str:
        char_arr = list(s)
        l,r = 0, len(s)-1
        
        while l < r:
            if self.is_vowel(char_arr[l]) and self.is_vowel(char_arr[r]):
                char_arr[l],char_arr[r] = char_arr[r],char_arr[l]
                l, r = l+1, r-1
                continue
            l = l if self.is_vowel(char_arr[l]) else l+1
            r = r if self.is_vowel(char_arr[r]) else r-1
        
        return ''.join(char_arr)
    
    def is_vowel(self, char):
        vowels = set("aeiouAEIOU")
        return char in vowels
