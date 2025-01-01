class Solution:
    def maxScore(self, s: str) -> int:
        ones = 0
        for num in s:
            ones += 1 if num == '1' else 0
        
        max_score = curr_zero = curr_one = 0
        for i in range(len(s)-1):
            if s[i] == '0': curr_zero += 1
            else: curr_one += 1

            curr_score = curr_zero + ones - curr_one
            max_score = max(max_score, curr_score)
        
        return max_score
