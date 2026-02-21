# high 4 bits represent hour and low 6 bits represent minute
# because hour has 4 digits and min has 6 digits in watch
# with that idea, check each number upto 2^10
class Solution:
    def readBinaryWatch(self, turnedOn: int) -> List[str]:
        ans = []
        for b in range(1024):
            h = b >> 6
            m = b & 63 # 63 = 0000111111
            if h < 12 and m < 60 and bin(b).count("1") == turnedOn:
                ans.append(f"{h}:{m:02d}")
        return ans