# we can do bfs here
# but the thing is, the queue will at max have only 2 values
# so why not just use 2 variables instead of a queue
# since there are only 2 rows, only a single turn can be made by any robot
# we have to just find out the turn where robot 2 gets 2nd best value
class Solution:
    def gridGame(self, grid: List[List[int]]) -> int:
        topRowSum, bottomRowSum, robot2Points = sum(grid[0]), 0, math.inf
        
        for i in range(len(grid[0])):
            topRowSum -= grid[0][i]
            robot2Points = min(robot2Points, max(topRowSum, bottomRowSum))
            bottomRowSum += grid[1][i]
        
        return robot2Points
