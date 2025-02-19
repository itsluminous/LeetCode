class Solution:
    def getHappyString(self, n: int, k: int) -> str:
        maxPossible = 3 * pow(2, n-1)
        if maxPossible < k: return ""

        # dict to find unused char based on prev value
        lookup = {'z': 'abc', 'a': 'bc', 'b': 'ac', 'c': 'ab'}
        
        ans = []
        prev = 'z'
        i = 1

        while len(ans) < n:
            mul = pow(2, n-i)
            q = (k - 1) // mul      # because k is 1-indexed
            k = (k - 1) % mul + 1   # adding 1 to keep k as 1-indexed
            
            curr = lookup[prev][q]
            ans.append(curr)
            prev = curr
            i += 1
            
        return ''.join(ans)