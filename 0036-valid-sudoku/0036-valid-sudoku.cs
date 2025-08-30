public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var hashSet = new HashSet<string>();
        
        for(int i=0; i<9; i++){
            for(int j=0; j<9; j++){
                if(board[i][j] != '.')
                {
                    if(!hashSet.Add(board[i][j] + "found in row " + i) ||
                      !hashSet.Add(board[i][j] + "found in col " + j) ||
                      !hashSet.Add(board[i][j] + "found in box " + i/3 + "-" + j/3))
                        return false;
                }
            }
        }
        return true;
    }
    
    public bool IsValidSudoku1(char[][] board) {
        var row = new HashSet<string>();
        var col = new HashSet<string>();
        var grid = new HashSet<string>();
        
        var r = board.Length;
        var c = board[0].Length;
        
        for(int i=0; i<r; i++){
            for(int j=0; j<c; j++){
                if(board[i][j] != '.'){
                    if(!row.Add(i + "-" + board[i][j]))
                        return false;
                    if(!col.Add(j + "-" + board[i][j]))
                        return false;
                    if(!grid.Add(i/3 + "-" + j/3 + '-' + board[i][j]))
                        return false;
                }
            }
        }
        
        return true;
    }
}