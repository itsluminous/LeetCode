class Solution:
    def convert(self, s: str, numRows: int) -> str:
        sb = [''] * numRows

        n, idx = len(s), 0
        while idx < n:
            # fill down
            for i in range(numRows):
                if idx == n: break
                sb[i] += s[idx]
                idx += 1
                

            # fill diag up
            for i in range(numRows-2, 0, -1):
                if idx == n: break
                sb[i] += s[idx]
                idx += 1

        # concatenate all stringbuilders
        return ''.join(sb)