class Solution:
    def letterCombinations(self, digits: str) -> List[str]:
        keypad = ["", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz"]
        self.combination = []
        self.backtracking(keypad, digits, 0, [])
        return self.combination

    def backtracking(self, keypad, digits, idx, sb):
        if idx == len(digits): return
        for ch in keypad[ord(digits[idx])-ord('0')]:
            sb.append(ch)
            if idx == len(digits)-1: self.combination.append(''.join(sb))
            else: self.backtracking(keypad, digits, idx+1, sb)
            sb.pop()