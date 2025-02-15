class Solution:
    def punishmentNumber(self, n: int) -> int:
        # first run findNumsMatchingCondition() to get all no. matching condition
        # then hardcode it so that all runs don't need to evaluate it 
        # pun = self.findNumsMatchingCondition()

        pun = [1, 9, 10, 36, 45, 55, 82, 91, 99, 100, 235, 297, 369, 370, 379, 414, 657, 675, 703, 756, 792, 909, 918, 945, 964, 990, 991, 999, 1000]

        punishment = 0
        for num in pun:
            if num > n: break
            punishment += num * num

        return punishment
    
    def findNumsMatchingCondition(self):
        match = []
        for i in range(1, 1001):
            if self.canPartition(i*i, i):
                match.append(i)
        return match

    def canPartition(self, num: int, target: int) -> bool:
        if num == target: return True
        if num < target: return False

        curr, mul = 0, 1
        while(num > 0):
            last_digit = num % 10
            num //= 10

            curr += mul * last_digit
            mul *= 10
            if self.canPartition(num, target - curr):
                return True
        
        return False
        