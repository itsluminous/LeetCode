public class Solution {
    public boolean exist(char[][] board, String word) {
        int m = board.length, n = board[0].length;
        var chars = word.toCharArray();
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(exist(board, chars, 0, i, j))
                    return true;
        return false;
    }

    private boolean exist(char[][] board, char[] word, int idx, int x, int y) {
        if(idx == word.length) return true;
        if(!validMove(board, x, y)) return false;
        if(board[x][y] != word[idx]) return false;

        board[x][y] ^= 256;
        var present = exist(board, word, idx+1, x-1, y)
                   || exist(board, word, idx+1, x+1, y)
                   || exist(board, word, idx+1, x, y-1)
                   || exist(board, word, idx+1, x, y+1);
        board[x][y] ^= 256;
        return present;
    }

    private boolean validMove(char[][] board, int x, int y){
        int m = board.length, n = board[0].length;
        if(x == -1 || x == m || y == -1 || y == n) return false;
        return true;
    }
}