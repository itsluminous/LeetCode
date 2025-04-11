class Solution:
    def countSymmetricIntegers(self, low: int, high: int) -> int:
        count = 0

        for num in range(low, high+1):
            if num < 10 or (num >= 100 and num < 1000) or num == 10000: continue  # odd digits

            # for two digit num, just check if both digits are equal
            if num < 100:
                # left & right will be same if num % 11 == 0
                if num % 11 == 0:
                    count += 1
                continue

            # if we reached here, num is guaranteed to be 4 digits
            left, right = num // 100, num % 100
            leftSum = left // 10 + left % 10
            rightSum = right // 10 + right % 10
            if leftSum == rightSum: count += 1

        return count