public class Solution {
    int[][] dirs = {new[]{0,1}, new[]{1,0}, new[]{0,-1}, new[]{-1,0}, new[]{-1,-1}, new[]{1,1}, new[]{1,-1}, new[]{-1,1}};

    public char[][] UpdateBoard(char[][] board, int[] click) {
        var (r,c) = (click[0], click[1]);
        if(board[r][c] == 'M'){
            board[r][c] = 'X';
            return board;
        }
        board[r][c] = 'B';

        // count mines in neighbours
        var mines = 0;
        for(var i=0; i<8; i++){
            int nr = r + dirs[i][0], nc = c + dirs[i][1];
            if(nr == -1 || nc == -1 || nr == board.Length || nc == board[0].Length) continue;
            if(board[nr][nc] == 'M' || board[nr][nc] == 'X') mines++;
        }

        // Perform DFS, if needed, to update other cells
        if(mines != 0) 
            board[r][c] = (char)(mines + '0');
        else
            for(var i=0; i<8; i++){
                int nr = r + dirs[i][0], nc = c + dirs[i][1];
                if(nr == -1 || nc == -1 || nr == board.Length || nc == board[0].Length) continue;
                if(board[nr][nc] == 'E') UpdateBoard(board, new[]{nr, nc});
            }
        return board;
    }
}