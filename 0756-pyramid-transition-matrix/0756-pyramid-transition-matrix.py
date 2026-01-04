class Solution:
    def pyramidTransition(self, bottom: str, allowed: List[str]) -> bool:
        # build a map of allowed sets
        map_grid = [[0] * 7 for _ in range(7)]
        for al in allowed:
            map_grid[ord(al[0]) - ord('A')][ord(al[1]) - ord('A')] |= 1 << (ord(al[2]) - ord('A'))
        
        # convert bottom row to int for ease of operations
        n = len(bottom)
        row = [ord(ch) - ord('A') for ch in bottom]
        
        # try all permutations now
        return self.solve(map_grid, row, 0, n)
    
    def solve(self, map_grid: list[list[int]], row: list[int], start: int, end: int) -> bool:
        # only one cell left in row, no more rows need to be built
        if end == 1: return True
        
        # if start has reached end-1, then build new row
        if start == end - 1: return self.solve(map_grid, row, 0, end - 1)
        
        # get all possible blocks that can be placed on top of row[start] and row[start+1]
        val = map_grid[row[start]][row[start + 1]]
        if val == 0: return False  # no valid block can be placed
        
        # try each possible block
        orig = row[start]
        mask = 1
        for num in range(7):
            if (mask & val) != 0:  # this block is allowed
                row[start] = num   # place this block
                if self.solve(map_grid, row, start + 1, end): return True  # found solution
            mask <<= 1
        
        row[start] = orig   # backtrack
        return False        # no valid solution found