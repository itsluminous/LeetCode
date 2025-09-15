class Solution:
    def canBeTypedWords(self, text: str, brokenLetters: str) -> int:
        broken = [0] * 26   # 1 if broken, 0 if not
        for ch in brokenLetters:
            broken[ord(ch) - ord('a')] = 1

        ans = curr = 0
        for ch in text:
            if ch == ' ':
                if curr == 0: ans += 1
                curr = 0
            else:
                curr += broken[ord(ch) - ord('a')]

        if curr == 0: ans += 1
        return ans

# Accepted - slow
class Solution1:
    def canBeTypedWords(self, text: str, brokenLetters: str) -> int:
        words = text.split(" ")
        broken = 0

        for word in words:
            for ch in brokenLetters:
                if ch in word:
                    broken += 1
                    break

        return len(words) - broken