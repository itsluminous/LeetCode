class Solution:
    def shiftingLetters(self, s: str, shifts: List[List[int]]) -> str:
        n = len(s)
        pre = [0] * (n+1)

        for start, end, dirr in shifts:
            if dirr == 0: dirr = -1
            pre[start] += dirr
            pre[end+1] -= dirr

        chars = list(s)
        shift = 0
        for i in range(n):
            shift = (shift + pre[i]) % 26
            if shift < 0: shift += 26

            pos = (ord(s[i]) - ord('a') + shift) % 26
            chars[i] = chr(ord('a') + pos)

        return "".join(chars)