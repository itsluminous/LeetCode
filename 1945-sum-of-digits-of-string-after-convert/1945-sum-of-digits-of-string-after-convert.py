class Solution:
    def getLucky(self, s: str, k: int) -> int:
        total = 0
        for ch in s:
            total += self.digitSum((ord(ch) - ord('a')) + 1)
        
        while k > 1:
            total = self.digitSum(total)
            k -= 1

        return total
    
    def digitSum(self, num: int) -> int:
        total = 0
        while num > 9:
            total += num % 10
            num //= 10
        total += num

        return total