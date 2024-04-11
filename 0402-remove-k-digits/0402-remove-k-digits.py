class Solution:
    def removeKdigits(self, num: str, k: int) -> str:
        n, i = len(num), 0
        if(n == k): return '0'  # if both are same length then result will be 0

        stack = []
        while i<n:
            # store only the smaller digit on top of stack
            while k>0 and stack and stack[-1] > num[i]:
                stack.pop()
                k -= 1
            
            # don't add "0" as first digit in stack, because it has no value
            if stack or num[i] != '0':
                stack.append(num[i])
            i += 1
        
        # if k is not 0, remove last k elements (for case like "12345" or "11111")
        while stack and k>0:
            stack.pop()
            k -= 1

        # return the final string
        if not stack: return '0'
        return ''.join(stack)