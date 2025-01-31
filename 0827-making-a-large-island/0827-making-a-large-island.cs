public class Solution {
    HashSet<int>[,] neighbours;
    bool zeroFound = false;

    public int LargestIsland(int[][] grid) {
        int n = grid.Length, maxSize = 1;
        var size = new Dictionary<int, int>();  // what is size of each island

        // to track neighbouring islands of each cell
        neighbours = new HashSet<int>[n,n];
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++)
                neighbours[i,j] = new HashSet<int>();

        var islandIdx = 1;
        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                if(grid[i][j] == 0 || grid[i][j] == -1) continue;
                var currSize = TraverseIsland(grid, islandIdx, i, j);
                size[islandIdx++] = currSize;
                maxSize = Math.Max(maxSize, currSize + 1);
            }
        }

        if(islandIdx == 1) return 1;        // grid is full of zeroes
        if(!zeroFound) return maxSize-1;    // grid is full of ones
        if(islandIdx == 2) return maxSize;  // only one island in grid

        // now try to set each 0 to 1, one by one and maximize area
        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                if(neighbours[i,j].Count <= 1) continue;
                var newSize = 1;
                foreach(var isl in neighbours[i,j]) newSize += size[isl];
                maxSize = Math.Max(maxSize, newSize);
            }
        }

        return maxSize;
    }

    private int TraverseIsland(int[][] grid, int islandIdx, int x, int y) {
        if(x == -1 || y == -1 || x == grid.Length || y == grid[0].Length || grid[x][y] == -1) return 0;
        if(grid[x][y] == 0){
            neighbours[x, y].Add(islandIdx);
            zeroFound = true;
            return 0;
        }

        grid[x][y] = -1;
        var size = 1; 
        size += TraverseIsland(grid, islandIdx, x-1, y);
        size += TraverseIsland(grid, islandIdx, x+1, y);
        size += TraverseIsland(grid, islandIdx, x, y-1);
        size += TraverseIsland(grid, islandIdx, x, y+1);

        return size;
    }
}