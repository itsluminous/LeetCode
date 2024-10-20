class Solution:
    def parseBoolExpr(self, expression: str) -> bool:
        n = len(expression)
        if n == 1: return expression == "t"   # only one char in expression
        if expression[0] == '!': return not self.parseBoolExpr(expression[2 : n-1])

        isAnd = True if expression[0] == '&' else False
        val = isAnd    # True by default for AN : False by default for OR

        start = end = 2
        count = 0
        while end < n and val == isAnd:
            # count opening & closing brackets
            if expression[end] == '(': count += 1
            if expression[end] == ')': count -= 1

            # self.parseBoolExpr expression if we found a matching closing bracket
            if end == n-1 or (expression[end] == ',' and count == 0):
                if isAnd: val &= self.parseBoolExpr(expression[start : end])
                else: val |= self.parseBoolExpr(expression[start : end])
                start = end+1
            end += 1

        return val