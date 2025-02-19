class Solution {
    List<List<String>> ans;
    int colQueen, diagQueen, antiDiagQueen;

    public List<List<String>> solveNQueens(int n) {
        var chessboard = new boolean[n][n];
        ans = new ArrayList<>();
        colQueen = diagQueen = antiDiagQueen = 0;
        
        placeQueen(chessboard, 0);
        return ans;
    }

    private void placeQueen(boolean[][] chessboard, int row){
        var n = chessboard.length;
        
        if(row == n){
            addAnswer(chessboard);
            return;
        }

        for(var col=0; col<n; col++){
            if(!canPlace(chessboard, row, col))
                continue;

            var diag = n + row - col;
            var antiDiag = row + col;

            chessboard[row][col] = true;
            colQueen |= (1 << col);
            diagQueen |= (1 << diag);
            antiDiagQueen |= (1 << antiDiag);
            
            placeQueen(chessboard, row+1);

            antiDiagQueen ^= (1 << antiDiag);
            diagQueen ^= (1 << diag);
            colQueen ^= (1 << col);
            chessboard[row][col] = false;
        }
    }

    private boolean canPlace(boolean[][] chessboard, int x , int y){
        var diag = chessboard.length + x - y;
        var antiDiag = x + y;

        if((colQueen & (1 << y)) != 0) return false;
        if((diagQueen & (1 << diag)) != 0) return false;
        if((antiDiagQueen & (1 << antiDiag)) != 0) return false;

        return true;
    }

    private void addAnswer(boolean[][] chessboard){
        var n = chessboard.length;
        var rowList = new ArrayList<String>();

        for(var row=0; row < n; row++){
            var sb = new StringBuilder();
            for(var col=0; col < n; col++){
                if(chessboard[row][col])
                    sb.append("Q");
                else
                    sb.append(".");
            }
            rowList.add(sb.toString());
        }

        ans.add(rowList);
    }
}

// Accepted - using array to track col and both diagonals
class SolutionArr {
    List<List<String>> ans;
    boolean[] colQueen, diagQueen, antiDiagQueen;

    public List<List<String>> solveNQueens(int n) {
        var chessboard = new boolean[n][n];
        ans = new ArrayList<>();

        colQueen = new boolean[n];
        diagQueen = new boolean[1 + n*n];
        antiDiagQueen = new boolean[1 + n*n];
        
        placeQueen(chessboard, 0);
        return ans;
    }

    private void placeQueen(boolean[][] chessboard, int row){
        var n = chessboard.length;
        
        if(row == n){
            addAnswer(chessboard);
            return;
        }

        for(var col=0; col<n; col++){
            if(!canPlace(chessboard, row, col))
                continue;

            var diag = n + row - col;
            var antiDiag = row + col;

            chessboard[row][col] = true;
            colQueen[col] = true;    
            diagQueen[diag] = true;
            antiDiagQueen[antiDiag] = true;
            
            placeQueen(chessboard, row+1);

            antiDiagQueen[antiDiag] = false;
            diagQueen[diag] = false;
            colQueen[col] = false;
            chessboard[row][col] = false;
        }
    }

    private boolean canPlace(boolean[][] chessboard, int x , int y){
        var diag = chessboard.length + x - y;
        var antiDiag = x + y;

        if(colQueen[y] || diagQueen[diag] || antiDiagQueen[antiDiag]) return false;
        return true;
    }

    private void addAnswer(boolean[][] chessboard){
        var n = chessboard.length;
        var rowList = new ArrayList<String>();

        for(var row=0; row < n; row++){
            var sb = new StringBuilder();
            for(var col=0; col < n; col++){
                if(chessboard[row][col])
                    sb.append("Q");
                else
                    sb.append(".");
            }
            rowList.add(sb.toString());
        }

        ans.add(rowList);
    }
}