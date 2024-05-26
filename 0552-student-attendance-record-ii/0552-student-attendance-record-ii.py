# Explaination : https://leetcode.com/problems/student-attendance-record-ii/solutions/101652/java-4-lines-dp-solution-with-state-transition-table-explained/
class Solution:
    def checkRecord(self, n: int) -> int:
        self.dp = [1, 1, 0, 1, 0, 0]    # initial state for n = 1
        for i in range(2, n+1):
            self.dp = [ self.dp_sum(0, 2), self.dp[0], self.dp[1], self.dp_sum(0, 5), self.dp[3], self.dp[4] ]
        return self.dp_sum(0, 5)
    
    def dp_sum(self, start: int, end: int):
        MOD, total = 1_000_000_007, 0
        for i in range(start, end+1):
            total = (total + self.dp[i]) % MOD
        return total