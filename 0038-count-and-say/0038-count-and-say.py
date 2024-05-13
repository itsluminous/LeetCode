class Solution:
    def countAndSay(self, n: int) -> str:
        if n == 1: return '1'
        rle = self.countAndSay(n-1)

        new_rle = []
        i = len(rle)-1
        while i >= 0:
            ch, count = rle[i], 0
            while i >= 0 and rle[i] == ch:
                i, count = i-1, count+1
            new_rle.append(ch + str(count))
        
        return ''.join(new_rle)[::-1]   # reverse