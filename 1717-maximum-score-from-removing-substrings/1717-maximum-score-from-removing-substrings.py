class Solution:
    def maximumGain(self, s: str, x: int, y: int) -> int:
        self.maxPoints = 0
        
        def match(target: str, points: int) -> str:
            stk = []
            for ch in s:
                if ch == target[1] and stk and stk[-1] == target[0]:
                    self.maxPoints += points
                    stk.pop()
                else:
                    stk.append(ch)
            return ''.join(stk)
        
        if x > y:
            s = match("ab", x)
            match("ba", y)
        else:
            s = match("ba", y)
            match("ab", x)
        
        return self.maxPoints
        
                

        
    
