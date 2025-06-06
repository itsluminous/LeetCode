class Solution:
    def robotWithString(self, s: str) -> str:
        freq = [0] * 123  # ascii of z is 122
        for ch in s:
            freq[ord(ch)] += 1

        ans, stack = [], []

        for ch in s:
            stack.append(ch)
            freq[ord(ch)] -= 1

            # Find the smallest available char in s
            c = ord('a')
            while c <= ord('z') and freq[c] == 0: c += 1

            # While stack top is <= remaining min character, pop to ans
            while stack and (c == ord('z') + 1 or stack[-1] <= chr(c)):
                ans.append(stack.pop())

        # Append remaining characters from stack
        while stack: ans.append(stack.pop())

        return ''.join(ans)