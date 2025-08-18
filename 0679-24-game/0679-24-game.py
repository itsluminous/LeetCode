class Solution:
    def judgePoint24(self, cards: List[int]) -> bool:
        self.delta = 0.001  # to keep decimal till 3 places only
        arr = [float(card) for card in cards]
        return self.evaluate(arr)

    def evaluate(self, arr):
        if len(arr) == 1:
            if abs(arr[0] - 24.0) < self.delta:
                return True
            return False

        # try all permutations of two numbers
        for i in range(len(arr)):
            for j in range(i):
                next_arr = []
                n1, n2 = arr[i], arr[j]

                # add all possible operations between n1 & n2
                next_arr.extend([n1 + n2, n1 - n2, n2 - n1, n1 * n2])
                if abs(n1) > self.delta: next_arr.append(n2 / n1)
                if abs(n2) > self.delta: next_arr.append(n1 / n2)

                # backtracking
                temp = arr[:]
                temp.pop(i)
                temp.pop(j)
                for nxt in next_arr:
                    temp.append(nxt)
                    if self.evaluate(temp): return True
                    temp.pop()

        return False