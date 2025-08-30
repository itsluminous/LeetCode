class Solution:
    def isValidSudoku(self, board: List[List[str]]) -> bool:
        seen = set()
        for i in range(9):
            for j in range(9):
                if board[i][j] == '.': continue
                if (f"{i}_row_{board[i][j]}" in seen or
                    f"{j}_col_{board[i][j]}" in seen or
                    f"{i//3}{j//3}_box_{board[i][j]}" in seen):
                    return False
                seen.add(f"{i}_row_{board[i][j]}")
                seen.add(f"{j}_col_{board[i][j]}")
                seen.add(f"{i//3}{j//3}_box_{board[i][j]}")
        return True