class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:
        m,n = len(board), len(board[0])
        for i in range(m):
            for j in range(n):
                if self.exist_helper(board, word, 0, i, j):
                    return True
        return False

    def exist_helper(self, board: List[List[str]], word: str, idx: int, x: int, y: int) -> bool:
        if idx == len(word):
            return True
        if not self.valid_move(board, x, y) or board[x][y] != word[idx]:
            return False

        orig = board[x][y]
        board[x][y] = None
        present = (self.exist_helper(board, word, idx+1, x-1, y)
                or self.exist_helper(board, word, idx+1, x+1, y)
                or self.exist_helper(board, word, idx+1, x, y-1)
                or self.exist_helper(board, word, idx+1, x, y+1))
        board[x][y] = orig;
        return present;

    def valid_move(self, board: List[List[str]], x: int, y: int) -> bool:
        m,n = len(board), len(board[0])
        if x == -1 or x == m or y == -1 or y == n:
            return False
        return True