// any 'O' on boundary cannot be captured
// any 'O' connected to un-capturable cell cannot be captured
// so we start from boundary and mark all 'O' cells that cannot be captured
// then we capture remaining ones

public class Solution {
    (int, int)[] dirs = [(0, 1), (0, -1), (1, 0), (-1, 0)];
    int m, n;
    char o = 'O', x = 'X', mrk = 'M';

    public void Solve(char[][] board) {
        m = board.Length;
        n = board[0].Length;

        // check connected 'O' from the first and last row
        for(var j=0; j<n; j++){
            if(board[0][j] == o) Mark(board, 0, j);
            if(board[m-1][j] == o) Mark(board, m-1, j);
        }

        // check connected 'O' from the first and last col
        for(var i=1; i<m-1; i++){
            if(board[i][0] == o) Mark(board, i, 0);
            if(board[i][n-1] == o) Mark(board, i, n-1);
        }

        // change marked cells to o and other o cells to x as they are captured
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(board[i][j] == mrk) board[i][j] = o;
                else if(board[i][j] == o) board[i][j] = x;
    }

    private void Mark(char[][] board, int x, int y){
        board[x][y] = mrk;

        foreach(var (dx, dy) in dirs){
            int nx = x + dx, ny = y + dy;
            if(nx == -1 || ny == -1 || nx == m || ny == n || board[nx][ny] != o) continue;
            Mark(board, nx, ny);
        }
    }
}