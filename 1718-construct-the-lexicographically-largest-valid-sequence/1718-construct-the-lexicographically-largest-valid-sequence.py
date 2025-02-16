class Solution:
    def constructDistancedSequence(self, n: int) -> List[int]:
        if n == 1: return [1]

        self.lenn = 2 * (n-1) + 1
        self.ans = [0] * self.lenn
        self.visited = [False] * (n+1)

        self.placeNums(n, 0)
        return self.ans

    # place the best possible, biggest unplaced num at "idx"
    def placeNums(self, n, idx):
        if idx == self.lenn: return True     # filled all nums

        for num in range(n, 0, -1):
            if self.visited[num]: continue  # this num is already filled in ans

            secIdx = idx if num == 1 else idx+num  # second index of curr num
            if secIdx >= self.lenn or self.ans[idx] != 0 or self.ans[secIdx] != 0: continue

            # place current num
            self.ans[idx] = self.ans[secIdx] = num
            self.visited[num] = True

            # place remaining nums
            nextIdx = 0
            while nextIdx < self.lenn and self.ans[nextIdx] != 0: nextIdx += 1
            if self.placeNums(n, nextIdx): return True

            # rollback current num placement
            self.visited[num] = False
            self.ans[idx] = self.ans[secIdx] = 0
        return False