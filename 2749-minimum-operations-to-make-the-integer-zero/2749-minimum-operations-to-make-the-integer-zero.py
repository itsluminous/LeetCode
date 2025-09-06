class Solution:
    def makeTheIntegerZero(self, num1: int, num2: int) -> int:
        if num2 >= num1: return -1
        steps = 0
        
        while True:
            num = num1 - num2 * steps
            if num < steps: return -1
            
            # check if remaining number is power of 2
            if steps >= num.bit_count():
                return steps
            
            steps += 1