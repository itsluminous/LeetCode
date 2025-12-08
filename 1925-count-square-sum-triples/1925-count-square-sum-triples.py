class Solution:
    def countTriples(self, n: int) -> int:
        count = 0
        
        for n1 in range(1, n+1):
            for n2 in range(1, n+1):
                sum = n1*n1 + n2*n2
                n3 = int(sqrt(sum))
                if n3 <= n and n3*n3 == sum: count += 1

        return count