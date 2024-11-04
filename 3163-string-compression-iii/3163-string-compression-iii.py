class Solution:
    def compressedString(self, word: str) -> str:
        n, count = len(word), 0
        ans = []

        left = right = 0
        while right < n:
            count = 0
            while right < n and word[left] == word[right] and count < 9:
                right += 1
                count += 1
            ans.append(str(count))
            ans.append(word[left])
            left = right

        return ''.join(ans)