class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        n = len(digits)
        for i in range(n-1, -1, -1):
            if digits[i] < 9:
                digits[i] += 1
                return digits
            digits[i] = 0

        # handle case where extra digit needs to be added
        ans = [0] * (n+1)
        ans[0] = 1
        return ans