class Solution:
    def addBinary(self, a: str, b: str) -> str:
        sb = []
        carry = 0
        n1, n2 = len(a)-1, len(b)-1
        while n1 >= 0 or n2 >= 0:
            currSum = carry
            if n1 >= 0: currSum += int(a[n1])
            if n2 >= 0: currSum += int(b[n2])
            sb.append(str(currSum % 2))     # if currSum==2 or currSum==0 append 0
            carry = currSum//2         # if currSum==2 we have a carry, else no
            n1 -= 1
            n2 -= 1
        if carry == 1: sb.append(str(carry))    # add leftover carry
        return ''.join(reversed(sb))