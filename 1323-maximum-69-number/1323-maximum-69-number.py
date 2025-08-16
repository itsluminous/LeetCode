class Solution:
    def maximum69Number (self, num: int) -> int:
        mask = self.getMask(num)    # for number like 9669, mask will be 1000
        ans = 0
        flip = False   # has flip been done?

        while num > 0:
            digit = num // mask
            if not flip and digit == 6:
                ans += mask * 9
                flip = True
            else:
                ans += mask * digit
            
            num = (num % (digit * mask))
            mask //= 10

        return ans

    def getMask(self, num):
        mask = 1
        while num >= 10:
            num //= 10
            mask *= 10
        return mask