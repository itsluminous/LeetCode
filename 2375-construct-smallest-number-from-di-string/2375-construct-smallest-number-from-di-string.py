# https:#leetcode.com/problems/construct-smallest-number-from-di-string/solutions/2422380/java-c-python-easy-reverse/
# Using stack - O(N)
class Solution:
    def smallestNumber(self, pattern: str) -> str:
        n = len(pattern)
        num, stack = [], []

        for i in range(n+1):
            stack.append(str(1 + i))
            if i == n or pattern[i] == 'I':
                num.extend(reversed(stack))
                stack.clear()

        return ''.join(num)
    
# Accepted - Backtracking - O(9! * N)
# implemented in java & c#