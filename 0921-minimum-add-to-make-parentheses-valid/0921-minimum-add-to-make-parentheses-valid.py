class Solution:
    def minAddToMakeValid(self, s: str) -> int:
        openn = close = 0
        for ch in s:
            if ch == '(': openn += 1
            elif openn > 0: openn -= 1
            else: close += 1

        # we will have to balance leftover open & close brackets
        return openn + close