class Solution:
    def checkValidString(self, s: str) -> bool:
        open_max = 0
        open_min = 0

        for ch in s:
            if ch == '(':
                open_max += 1
                open_min += 1
            elif ch == ')':
                open_max -= 1
                open_min -= 1
            else:
                open_max += 1    # if * becomes '('
                open_min -= 1    # if * becomes ')'

            open_min = max(open_min, 0)   # open_min cannot be negative
            if open_max < 0:             # // not enough '(' to close parenthesis
                return False

        return open_min == 0