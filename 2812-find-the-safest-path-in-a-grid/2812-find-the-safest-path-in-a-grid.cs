public class Solution {
    (int, int)[] dirs;

    public int MaximumSafenessFactor(IList<IList<int>> grid) {
        var n = grid.Count;
        if(grid[0][0] == 1 || grid[^1][^1] == 1) return 0;

        dirs = new []{(1, 0), (-1, 0), (0, 1), (0, -1)};

        // find all thieves and distance from thieves
        var queue = new Queue<(int, int)>();    // queue to track thieves
        for(var i=0; i<n; i++)
            for(var j=0; j<n; j++)
                if(grid[i][j] == 1){
                    queue.Enqueue((i,j));
                    grid[i][j] = 0;     // distance from thief is 0
                }
                else grid[i][j] = -1;   // distance from thief is not yet calculated
        
        // use BFS to calculate distance of all non-thief cells from thieves
        var distance = 0;
        for(distance=0; queue.Count > 0; distance++){
            for(var i=queue.Count; i>0; i--){
                var (x,y) = queue.Dequeue();
                foreach(var (dx, dy) in dirs){
                    var (newX, newY) = (x + dx, y + dy);
                    if(IsValid(grid, newX, newY) && grid[newX][newY] == -1){
                        grid[newX][newY] = distance+1;
                        queue.Enqueue((newX, newY));
                    }   
                }
            }
        }

        // try to find path with max safeness factor
        // we try different safeness factors as target one by one, using binary search
        int left = 0, right = distance-1, ans = -1;
        while(left <= right){
            var mid = left + (right-left)/2;
            if(SafenessFactorExists(grid, mid)){
                ans = mid;
                left = mid+1;
            }
            else
                right = mid-1;
        }

        return ans;
    }

    // start from cell (0,0) and try to reach last cell using BFS
    private bool SafenessFactorExists(IList<IList<int>> grid, int safenessFactor){
        if(grid[0][0] < safenessFactor) return false;

        var n = grid.Count;
        var visited = new bool[n,n];
        var queue = new Queue<(int, int)>();
        
        queue.Enqueue((0,0));
        visited[0,0] = true;

        while(queue.Count > 0){
            for(var i=queue.Count; i>0; i--){
                var (x,y) = queue.Dequeue();
                if(x == n-1 && y == n-1) return true;     // reached last cell
                foreach(var (dx, dy) in dirs){
                    var (newX, newY) = (x + dx, y + dy);
                    if(IsValid(grid, newX, newY) && !visited[newX,newY] && grid[newX][newY] >= safenessFactor){
                        queue.Enqueue((newX, newY));
                        visited[newX, newY] = true;
                    }
                }
            }
        }
        return false;
    }

    // check boundary conditions
    private bool IsValid(IList<IList<int>> grid, int x, int y){
        var n = grid.Count;
        if(x == -1 || y == -1 || x == n || y == n) return false;
        return true;
    }

    // print grid for debugging
    private void PrintGrid(IList<IList<int>> grid){
        var n = grid.Count;
        for(var i=0; i<n; i++){
            for(var j=0; j<n; j++){
                Console.Write(grid[i][j] + ", ");
            }
            Console.WriteLine();
        }
    }
}