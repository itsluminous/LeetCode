public class Solution {
    public void gameOfLife(int[][] board) {
        int m = board.length, n = board[0].length;
        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                var alive = getNeighboursCount(board, i, j);
                if(board[i][j] == 1 && alive >= 2 && alive <= 3) board[i][j] = 3;   // will stay alive
                else if(board[i][j] == 0 && alive == 3) board[i][j] = 2;    // will rise from dead
            }
        }

        for(var i=0; i<m; i++){
            for(var j=0; j<n; j++){
                board[i][j] = board[i][j] >> 1;
            }
        }
    }

    private int getNeighboursCount(int[][] board, int i, int j){
        int m = board.length, n = board[0].length;
        var alive = 0;

        for(var x=-1; x<=1; x++){
            for(var y=-1; y<=1; y++){
                if(i+x == -1 || j+y == -1 || i+x == m || j+y == n) continue;
                alive += board[i+x][j+y] & 1;
            }
        }

        alive -= board[i][j];
        return alive;
    }
}