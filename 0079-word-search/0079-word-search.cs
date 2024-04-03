public class Solution {
    bool[,] visited;
    public bool Exist(char[][] board, string word) {
        int m = board.Length, n = board[0].Length;
        visited = new bool[m,n];
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                if(Exist(board, word, 0, i, j))
                    return true;
        return false;
    }

    private bool Exist(char[][] board, string word, int idx, int x, int y) {
        if(idx == word.Length) return true;
        if(!ValidMove(board, x, y)) return false;
        if(board[x][y] != word[idx]) return false;

        visited[x,y] = true;
        var exist = Exist(board, word, idx+1, x-1, y)
                 || Exist(board, word, idx+1, x+1, y)
                 || Exist(board, word, idx+1, x, y-1)
                 || Exist(board, word, idx+1, x, y+1);
        visited[x,y] = false;
        return exist;
    }

    private bool ValidMove(char[][] board, int x, int y){
        int m = board.Length, n = board[0].Length;
        if(x == -1 || x == m || y == -1 || y == n || visited[x,y]) return false;
        return true;
    }
}