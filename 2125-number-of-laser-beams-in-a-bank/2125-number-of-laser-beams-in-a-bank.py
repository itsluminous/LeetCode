class Solution:
    def numberOfBeams(self, bank: List[str]) -> int:
        prev = curr = sum = 0

        for bnk in bank:
            curr = bnk.count('1')
            sum += curr * prev
            if curr != 0:
                prev = curr
        return sum