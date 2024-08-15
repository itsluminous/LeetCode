class Solution:
    def lemonadeChange(self, bills: List[int]) -> bool:
        count = [0] * 21
        for bill in bills:
            count[bill] += 1
            if bill > 10 and count[10] > 0:
                bill -= 10
                count[10] -= 1
            while bill > 5 and count[5] > 0:
                bill -= 5
                count[5] -= 1
            if bill > 5: return False
        return True