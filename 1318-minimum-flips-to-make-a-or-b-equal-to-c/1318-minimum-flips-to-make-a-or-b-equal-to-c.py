class Solution:
    def minFlips(self, a: int, b: int, c: int) -> int:
        flips = 0
        while a != 0 or b != 0 or c != 0:
            abit = a & 1
            a >>= 1

            bbit = b & 1
            b >>= 1

            cbit = c & 1
            c >>= 1

            if (abit | bbit) != cbit and cbit == 0: flips += (abit + bbit)  # need to convert all 1 to 0
            elif (abit | bbit) != cbit: flips += 1                          # make anyone as 1 will work
        
        return flips