# log(k) - use AI to understand why this works
class Solution:
    def kthCharacter(self, k: int) -> str:
        # we just need to shift 'a' by count of number of 1s in k-1
        ones = bin(k-1).count('1')
        return chr(ord('a') + ones)

# accepted - O(k)
class SolutionLinear:
    def kthCharacter(self, k: int) -> str:
        chars = []
        chars.append('a')

        while len(chars) < k:
            lenn = len(chars)
            i = 0
            while i < lenn and len(chars) < k:
                chars.append(chr(ord(chars[i]) + 1))
                i += 1

        return chars[-1]