class Solution:
    def minimizeXor(self, num1: int, num2: int) -> int:
        num1set = bin(num1).count('1')
        num2set = bin(num2).count('1')
        mask = 1

        # if bit count is more in num1, remove higher bits
        # (by setting lower bits to 0 because it will be used for xor)
        while num1set > num2set:
            # when we find a 1 in num1 binary, set it to 0
            if (num1 & mask) == mask:
                num1 ^= mask
                num1set -= 1
            mask <<= 1

        # if bit count is less in num1, add lower bits
        while num1set < num2set:
            # when we find a 0 in num1 binary, set it to 1
            if (num1 & mask) != mask:
                num1 |= mask
                num1set += 1
            mask <<= 1
        
        # if bit count was already same
        # then no operation is needed
        return num1
