# any 'O' on boundary cannot be captured
# any 'O' connected to un-capturable cell cannot be captured
# so we start from boundary and mark all 'O' cells that cannot be captured
# then we capture remaining ones

class Solution:
    def solve(self, board: List[List[str]]) -> None:
        m, n = len(board), len(board[0])
        self.dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)]

        # check connected 'O' from the first and last row
        for j in range(n):
            if board[0][j] == 'O': self.mark(board, 0, j)
            if board[m-1][j] == 'O': self.mark(board, m-1, j)

        # check connected 'O' from the first and last col
        for i in range(1, m-1):
            if board[i][0] == 'O': self.mark(board, i, 0)
            if board[i][n-1] == 'O': self.mark(board, i, n-1)

        # change marked cells to o and other o cells to x as they are captured
        for i in range(m):
            for j in range(n):
                if board[i][j] == 'M': board[i][j] = 'O'
                elif board[i][j] == 'O': board[i][j] = 'X'
    
    def mark(self, board: List[List[str]], x: int, y: int):
        m, n = len(board), len(board[0])
        board[x][y] = 'M'

        for dx, dy in self.dirs:
            nx, ny = x + dx, y + dy
            if nx == -1 or ny == -1 or nx == m or ny == n or board[nx][ny] != 'O': continue
            self.mark(board, nx, ny)