from queue import PriorityQueue

class Solution:
    def maxPoints(self, grid: List[List[int]], queries: List[int]) -> List[int]:
        m, n, k = len(grid), len(grid[0]), len(queries)
        dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]
        
        # sort the queries in asc order, while maintaining index
        queryIdx = [[queries[i], i] for i in range(k)]
        queryIdx.sort()

        # create a min heap for processing smaller numbers in grid first
        pq = PriorityQueue()   # [num, x, y]
        pq.put([grid[0][0], 0, 0])
        grid[0][0] = 0 # mark visited
        
        # time to find answer for queries
        ans = [0] * k
        count = 0

        # Do BFS for each query, starting from smallest query
        for query, idx in queryIdx:
            while not pq.empty() and pq.queue[0][0] < query:
                num, x, y = pq.get()
                count += 1

                for dx, dy in dirs:
                    nx, ny = x + dx, y + dy
                    if nx == -1 or ny == -1 or nx == m or ny == n or grid[nx][ny] == 0: continue
                    
                    pq.put([grid[nx][ny], nx, ny])
                    grid[nx][ny] = 0   # mark visited

            ans[idx] = count

        return ans