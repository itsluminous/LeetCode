class Solution:
    def fractionToDecimal(self, numerator: int, denominator: int) -> str:
        if numerator == 0: return "0"

        ans = []

        # handle sign
        if (numerator < 0 or denominator < 0) and not (numerator < 0 and denominator < 0): ans.append("-")

        num = abs(numerator)
        den = abs(denominator)

        # integer part
        ans.append(str(num // den))
        num %= den
        if num == 0: return ''.join(ans)

        # fraction part
        ans.append(".")
        map = {}  # position when a digit was seen
        map[num] = len(ans)

        while num != 0:
            num *= 10
            ans.append(str(num // den))
            num %= den

            # found repeating numerator
            if num in map:
                left = map[num]
                ans.insert(left, "(")
                ans.append(")")
                break
            else:
                map[num] = len(ans)

        return ''.join(ans)