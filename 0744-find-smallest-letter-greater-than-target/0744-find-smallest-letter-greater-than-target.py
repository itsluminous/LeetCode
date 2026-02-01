class Solution:
    def nextGreatestLetter(self, letters: List[str], target: str) -> str:
        smallest = letters[0]
        diff = 30

        for ch in letters:
            curr = ord(ch) - ord(target)
            if curr > 0 and curr < diff:
                diff = curr
                smallest = ch

        return smallest