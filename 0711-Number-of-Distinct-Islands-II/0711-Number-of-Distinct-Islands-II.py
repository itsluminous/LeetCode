from typing import List

class Solution:
    def numDistinctIslands2(self, grid: List[List[int]]) -> int:
        m, n = len(grid), len(grid[0])
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        unique_shapes = set()
        shape = []

        def dfs(x, y):
            shape.append([x, y])
            grid[x][y] = 0  # visited

            for dx, dy in dirs:
                nx, ny = x + dx, y + dy
                if nx == -1 or ny == -1 or nx == m or ny == n or grid[nx][ny] == 0: continue
                dfs(nx, ny)
        
        def normalize(shape):
            shapes = [[] for _ in range(8)] # 8 possible re-orientations and mirrors of this shape

            for x, y in shape:
                shapes[0].append([x, y])
                shapes[1].append([x, -y])
                shapes[2].append([-x, y])
                shapes[3].append([-x, -y])
                shapes[4].append([y, x])
                shapes[5].append([y, -x])
                shapes[6].append([-y, x])
                shapes[7].append([-y, -x])
            
            for shp in shapes:
                shp.sort()
                for i in range(len(shp) - 1, -1, -1):
                    shp[i] = [shp[i][0] - shp[0][0], shp[i][1] - shp[0][1]]
            
            shapes.sort()
            return tuple(tuple(cell) for cell in shapes[0])

        for i in range(m):
            for j in range(n):
                if grid[i][j] == 0: continue
                shape = []
                dfs(i, j)
                unique_shapes.add(normalize(shape))

        return len(unique_shapes)
    



#################################### TESTING CODE #############################################


def tester():
    input1 = [[1, 1, 0, 0, 0], [1, 0, 0, 0, 0], [0, 0, 0, 0, 1], [0, 0, 0, 1, 1]]
    input2 = [[1, 1, 0, 0, 0], [1, 1, 0, 0, 0], [0, 0, 0, 1, 1], [0, 0, 0, 1, 1]]
    input3 = [[1, 1, 1, 0, 0], [1, 0, 0, 0, 1], [0, 1, 0, 0, 1], [0, 1, 1, 1, 0]]
    input4 = [[1, 0, 0, 0, 0], [0, 1, 1, 0, 1], [0, 0, 0, 0, 1], [0, 0, 0, 0, 1]] 
    input5 = [[1, 0, 0], [0, 1, 0], [0, 0, 1]]

    inputs = [input1, input2, input3, input4, input5]
    outputs = [1, 1, 2, 3, 1]

    solution = Solution()
    for i, input in enumerate(inputs):
        count = solution.numDistinctIslands2(input)
        print(f"{i} : Expected - {outputs[i]}, Actual - {count}")

tester()