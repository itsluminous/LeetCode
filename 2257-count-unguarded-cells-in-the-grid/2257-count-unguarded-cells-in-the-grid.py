class Solution:
    def countUnguarded(self, m: int, n: int, guards: List[List[int]], walls: List[List[int]]) -> int:
        UNGUARDED, GUARDED, GUARD, WALL = 0, 1, 2, 3

        # initialize grid with guards and walls
        grid = [[UNGUARDED for _ in range(n)] for _ in range(m)]
        for r, c in guards: grid[r][c] = GUARD
        for r, c in walls: grid[r][c] = WALL

        def markGuarded(row, col):
            # mark upwards
            for r in range(row - 1, -1, -1):
                if grid[r][col] in (WALL, GUARD): break
                grid[r][col] = GUARDED

            # mark downwards
            for r in range(row + 1, m):
                if grid[r][col] in (WALL, GUARD): break
                grid[r][col] = GUARDED

            # mark leftwards
            for c in range(col - 1, -1, -1):
                if grid[row][c] in (WALL, GUARD): break
                grid[row][c] = GUARDED

            # mark rightwards
            for c in range(col + 1, n):
                if grid[row][c] in (WALL, GUARD): break
                grid[row][c] = GUARDED

        # for every guard, mark cells in all directions as guarded
        for r, c in guards: markGuarded(r, c)

        # count unguarded cells
        count = 0
        for row in grid:
            for cell in row:
                if cell == UNGUARDED:
                    count += 1

        return count