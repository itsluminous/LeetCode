class Solution:
    def largestIsland(self, grid: List[List[int]]) -> int:
        n = len(grid)
        max_size = 1
        size = {}  # map to store the size of each island
        neighbours = [[set() for _ in range(n)] for _ in range(n)]  # to track neighbouring islands for each cell
        zero_found = False

        def traverse_island(x, y, island_idx):
            nonlocal zero_found
            if x < 0 or y < 0 or x >= n or y >= n or grid[x][y] == -1:
                return 0
            if grid[x][y] == 0:
                neighbours[x][y].add(island_idx)
                zero_found = True
                return 0

            grid[x][y] = -1
            size = 1
            size += traverse_island(x - 1, y, island_idx)
            size += traverse_island(x + 1, y, island_idx)
            size += traverse_island(x, y - 1, island_idx)
            size += traverse_island(x, y + 1, island_idx)

            return size

        island_idx = 1
        for i in range(n):
            for j in range(n):
                if grid[i][j] == 0 or grid[i][j] == -1:
                    continue
                curr_size = traverse_island(i, j, island_idx)
                size[island_idx] = curr_size
                max_size = max(max_size, curr_size + 1)
                island_idx += 1

        if island_idx == 1: return 1            # grid is full of zeroes
        if not zero_found: return max_size - 1  # grid is full of ones
        if island_idx == 2: return max_size     # only one island in the grid

        # try setting each 0 to 1 and maximize the area
        for i in range(n):
            for j in range(n):
                if len(neighbours[i][j]) <= 1: continue
                new_size = 1
                for isl in neighbours[i][j]:
                    new_size += size[isl]
                max_size = max(max_size, new_size)

        return max_size
