class Solution {
    private HashSet<Integer>[][] neighbours;
    private boolean zeroFound = false;

    public int largestIsland(int[][] grid) {
        int n = grid.length, maxSize = 1;
        Map<Integer, Integer> size = new HashMap<>();  // size of each island

        // Initialize the 2D array of HashSets to track neighbouring islands of each cell
        neighbours = new HashSet[n][n];
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                neighbours[i][j] = new HashSet<>();
            }
        }

        var islandIdx = 1;
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (grid[i][j] == 0 || grid[i][j] == -1) continue;
                var currSize = traverseIsland(grid, islandIdx, i, j);
                size.put(islandIdx++, currSize);
                maxSize = Math.max(maxSize, currSize + 1);
            }
        }

        if (islandIdx == 1) return 1;        // grid is full of zeroes
        if (!zeroFound) return maxSize - 1; // grid is full of ones
        if (islandIdx == 2) return maxSize; // only one island in grid

        // Try setting each 0 to 1 and maximize the area
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                if (neighbours[i][j].size() <= 1) continue;
                var newSize = 1;
                for (var isl : neighbours[i][j]) {
                    newSize += size.get(isl);
                }
                maxSize = Math.max(maxSize, newSize);
            }
        }

        return maxSize;
    }

    private int traverseIsland(int[][] grid, int islandIdx, int x, int y) {
        if (x == -1 || y == -1 || x == grid.length || y == grid[0].length || grid[x][y] == -1) return 0;
        if (grid[x][y] == 0) {
            neighbours[x][y].add(islandIdx);
            zeroFound = true;
            return 0;
        }

        grid[x][y] = -1;
        var size = 1;
        size += traverseIsland(grid, islandIdx, x - 1, y);
        size += traverseIsland(grid, islandIdx, x + 1, y);
        size += traverseIsland(grid, islandIdx, x, y - 1);
        size += traverseIsland(grid, islandIdx, x, y + 1);

        return size;
    }
}
