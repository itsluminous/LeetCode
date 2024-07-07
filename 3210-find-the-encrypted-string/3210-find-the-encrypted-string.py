class Solution:
    def getEncryptedString(self, s: str, k: int) -> str:
        n = len(s)
        ans = []

        for i in range(n):
            substitute = (i + k) % n
            ans.append(s[substitute])

        return ''.join(ans)