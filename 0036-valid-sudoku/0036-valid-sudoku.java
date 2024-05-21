class Solution {
    public boolean isValidSudoku(char[][] board) {
        var set = new HashSet<String>();
        for(var i=0; i<9; i++){
            for(var j=0; j<9; j++){
                if(board[i][j] == '.') continue;
                if(!set.add(i + "_row_" + board[i][j])) return false;
                if(!set.add(j + "_col_" + board[i][j])) return false;

                var b = "" + (i/3) + (j/3);
                if(!set.add(b + "_box_" + board[i][j])) return false;
            }
        }

        return true;
    }
}