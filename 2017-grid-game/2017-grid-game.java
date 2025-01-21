// we can do bfs here
// but the thing is, the queue will at max have only 2 values
// so why not just use 2 variables instead of a queue
// since there are only 2 rows, only a single turn can be made by any robot
// we have to just find out the turn where robot 2 gets 2nd best value
class Solution {
    public long gridGame(int[][] grid) {
        long topRowSum = Arrays.stream(grid[0]).asLongStream().sum(), bottomRowSum = 0, robot2Points = Long.MAX_VALUE;
        
        for(var i = 0; i < grid[0].length; ++i) {
            topRowSum -= grid[0][i];
            robot2Points = Math.min(robot2Points, Math.max(topRowSum, bottomRowSum));
            bottomRowSum += grid[1][i];
        }
        
        return robot2Points;
    }
}
