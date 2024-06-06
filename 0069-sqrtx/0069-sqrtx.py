class Solution:
    def mySqrt(self, x: int) -> int:
        if x <= 1: return x

        left, right = 1, x//2
        while True:
            mid = left + (right - left)//2
            if mid * mid > x:
                right = mid - 1
            elif (mid+1) * (mid+1) > x:
                    return mid
            else:
                left = mid + 1