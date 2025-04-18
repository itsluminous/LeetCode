class Solution:
    def countAndSay(self, n: int) -> str:
        rle = "1"
        for _ in range(n-1):
            i, curr = 0, ""

            while i < len(rle):
                ch = rle[i]
                count = 1
                while i+1 < len(rle) and rle[i+1] == ch:
                    count += 1
                    i += 1
                i += 1
                curr += str(count) + ch
            rle = curr

        return rle