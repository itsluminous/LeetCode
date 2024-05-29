class Solution:
    def numSteps(self, s: str) -> int:
        steps = carry = 0

        # carry will never become zero once it changes to 1, because of how the rules are in question
        for i in range(len(s)-1, 0, -1):
            if ord(s[i]) - ord('0') + carry == 1:
                steps += 2 # one step to add 1, and one step to divide by 2
                carry = 1
            else:
                steps += 1

        return steps + carry