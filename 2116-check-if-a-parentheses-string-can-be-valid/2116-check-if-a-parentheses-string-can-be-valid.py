class Solution:
    def canBeValid(self, s: str, locked: str) -> bool:
        n = len(s)
        if (n & 1) == 1: return False  # odd length can never be balanced

        # check from left for '(' and from right for ')'
        return self.validate(s, locked, '(', 0, 1) and \
               self.validate(s, locked, ')', n-1, -1)

    def validate(self, s: str, locked: str, op: str, start: int, dir: int) -> bool:
        n = len(s)
        bal = free = 0  # free will track all pos with bit = 0

        i = start
        while i >= 0 and i < n and free + bal >= 0:
            if locked[i] == '1':
                bal += 1 if s[i] == op else -1
            else:
                free += 1
            
            i += dir

        return abs(bal) <= free