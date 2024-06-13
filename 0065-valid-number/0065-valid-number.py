class Solution:
    def isNumber(self, s: str) -> bool:
        """
        ^ = start of string, $ = end of string, | = OR condition, ? = 0 to 1 times, + = 1 or more
        (-|\\+)?  = minus or plus 0 to 1 times
        (\\.\\d+)  = decimal followed by at least one digit
        (\\d+\\.\\d+)  = at least one digit, then exactly one decimal, followed by at least one digit
        (\\d+\\.)  = at least one digit followed by exactly one decimal
        \\d+  = at least one digit
        (e|E)  = small e or big E, exactly once
        (-|\\+)?  = minus or plus 0 to 1 times
        \\d+  = at least one digit
        """
        
        pattern = '^(-|\\+)?((\\.\\d+)|(\\d+\\.\\d+)|(\\d+\\.)|\\d+)((e|E)(-|\\+)?\\d+)?$';
        return re.match(pattern, s)