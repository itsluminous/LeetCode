// any 'O' on boundary cannot be captured
// any 'O' connected to un-capturable cell cannot be captured
// so we start from boundary and mark all 'O' cells that cannot be captured
// then we capture remaining ones

class Solution {
    int[][] dirs = {{0, 1}, {0, -1}, {1, 0}, {-1, 0}};
    int m, n;
    char o = 'O', x = 'X', mrk = 'M';

    public void solve(char[][] board) {
        m = board.length;
        n = board[0].length;

        // check connected 'O' from the first and last row
        for(var j=0; j<n; j++){
            if(board[0][j] == o) mark(board, 0, j);
            if(board[m-1][j] == o) mark(board, m-1, j);
        }

        // check connected 'O' from the first and last col
        for(var i=1; i<m-1; i++){
            if(board[i][0] == o) mark(board, i, 0);
            if(board[i][n-1] == o) mark(board, i, n-1);
        }

        // change marked cells to o and other o cells to x as they are captured
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(board[i][j] == mrk) board[i][j] = o;
                else if(board[i][j] == o) board[i][j] = x;
    }

    private void mark(char[][] board, int x, int y){
        board[x][y] = mrk;

        for(var dir : dirs){
            int dx = dir[0], dy = dir[1];
            int nx = x + dx, ny = y + dy;
            if(nx == -1 || ny == -1 || nx == m || ny == n || board[nx][ny] != o) continue;
            mark(board, nx, ny);
        }
    }
}