class Solution:
    def findEvenNumbers(self, digits: List[int]) -> List[int]:
        self.ans = []
        freq = [0] * 10
        for digit in digits: freq[digit] += 1

        # one by one, fill digits at each pos
        for d1 in range(1, 10):
            if freq[d1] == 0: continue
            freq[d1] -= 1
            self.fillOthers(freq, d1)
            freq[d1] += 1
        
        return self.ans

    def fillOthers(self, freq: List[int], d1: int) -> None:
        for d2 in range(0, 10):
            if freq[d2] == 0: continue
            freq[d2] -= 1
            self.fillLast(freq, d1, d2)
            freq[d2] += 1

    def fillLast(self, freq: List[int], d1: int, d2: int) -> None:
        for d3 in range(0, 10, 2):
            if freq[d3] == 0: continue
            num = d1 * 100 + d2 * 10 + d3
            self.ans.append(num)