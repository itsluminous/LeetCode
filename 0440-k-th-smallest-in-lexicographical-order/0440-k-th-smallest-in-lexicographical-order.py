class Solution:
    def findKthNumber(self, n: int, k: int) -> int:
        curr = 1
        k -= 1

        while k > 0:
            # how many steps are needed to move from curr to curr+1
            steps = self.calculateSteps(n, curr, curr+1)

            # if all steps can fit within bound of k, then we can jump to next one
            if steps <= k:
                curr += 1
                k -= steps
            # else, we need to try next level in tree
            else:
                curr *= 10
                k -= 1

        return curr
    
    def calculateSteps(self, n, num1, num2):
        steps = 0
        while num1 <= n:
            # if n = 102 & num1 = 100, then 102 - 100 = 2, but we want 3 (100, 101, 102)
            # hence we do min(n+1, num2) instead of min(n, num2)
            steps += min(n+1, num2) - num1
            # move to next level
            num1 *= 10
            num2 *= 10
        return steps