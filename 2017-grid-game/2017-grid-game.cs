// we can do bfs here
// but the thing is, the queue will at max have only 2 values
// so why not just use 2 variables instead of a queue
// since there are only 2 rows, only a single turn can be made by any robot
// we have to just find out the turn where robot 2 gets 2nd best value
public class Solution {
    public long GridGame(int[][] grid) {
        long topRowSum = grid[0].Select(n => (long)n).Sum(), bottomRowSum = 0, robot2Points = long.MaxValue;
        
        for(var i = 0; i < grid[0].Length; ++i) {
            topRowSum -= grid[0][i];
            robot2Points = Math.Min(robot2Points, Math.Max(topRowSum, bottomRowSum));
            bottomRowSum += grid[1][i];
        }
        
        return robot2Points;
    }
}
