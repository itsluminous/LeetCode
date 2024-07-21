# Bob can only win if total count of vowels is 0
class Solution:
    def doesAliceWin(self, s: str) -> bool:
        for ch in s:
            if ch in 'aeiou': return True
        return False