class Solution:
    def snakesAndLadders(self, board: List[List[int]]) -> int:
        n = len(board)
        dest = n * n
        visited = [False] * (dest + 1)
        cell_to_idx = self.get_cell_to_idx_map(n)

        queue = deque([1])
        visited[1] = True

        rolls = 0
        while queue:
            for _ in range(len(queue)):
                cell = queue.popleft()
                if cell == dest: return rolls
                for next_cell in range(cell + 1, min(cell + 6, dest) + 1):
                    x, y = cell_to_idx[next_cell]
                    actual_next = board[x][y] if board[x][y] != -1 else next_cell
                    if visited[actual_next]: continue
                    
                    queue.append(actual_next)
                    visited[actual_next] = True
            rolls += 1

        return -1

    def get_cell_to_idx_map(self, n):
        cell_to_idx = [None] * (n * n + 1)
        cell = 1
        left_to_right = True

        for r in range(n - 1, -1, -1):
            if left_to_right:
                for c in range(n):
                    cell_to_idx[cell] = (r, c)
                    cell += 1
            else:
                for c in range(n - 1, -1, -1):
                    cell_to_idx[cell] = (r, c)
                    cell += 1
            left_to_right = not left_to_right

        return cell_to_idx