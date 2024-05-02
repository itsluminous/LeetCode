# The robot stays in the circle only if at the end it doesn't stay pointing north, or it returns to home.
class Solution:
    def isRobotBounded(self, instructions: str) -> bool:
        x,y = 0,0
        dirs = [[0,1], [1,0], [0,-1], [-1,0]]
        idx = 0

        for dir in instructions:
            if dir == 'G':
                x += dirs[idx][0]
                y += dirs[idx][1]
            elif dir == 'L':
                idx = (idx+3) % 4
            elif dir == 'R':
                idx = (idx+1) % 4

        if x|y == 0: return True  # robot returned to home
        return idx > 0            # any direction except north facing will lead to cycle eventually