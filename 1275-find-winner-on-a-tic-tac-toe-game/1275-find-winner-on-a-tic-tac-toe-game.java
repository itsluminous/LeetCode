public class Solution {
    public String tictactoe(int[][] moves) {
        var status = new int[3][3];  // 3 cells for rows, 3 for cols, 2 for diag, 1 empty
        var player = new int[]{1, -1};

        var turn = 0;
        for(var move : moves){
            int r = move[0], c = move[1];
            status[0][r] += player[turn];               // row
            status[1][c] += player[turn];               // col
            if(r==c) status[2][0] += player[turn];      // left to right diag
            if(r+c==2) status[2][1] += player[turn];    // right to left diag

            if(status[0][r] == 3 || status[1][c] == 3 || status[2][0] == 3 || status[2][1] == 3) return "A";
            if(status[0][r] == -3 || status[1][c] == -3 || status[2][0] == -3 || status[2][1] == -3) return "B";

            turn = (turn+1)%2;
        }

        if(moves.length == 9) return "Draw";
        return "Pending";
    }
}