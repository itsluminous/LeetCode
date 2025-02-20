public class Solution {
    IList<IList<string>> ans;
    int colQueen, diagQueen, antiDiagQueen;

    public IList<IList<string>> SolveNQueens(int n) {
        var chessboard = new bool[n,n];
        ans = new List<IList<string>>();
        colQueen = diagQueen = antiDiagQueen = 0;
        
        PlaceQueen(chessboard, 0);
        return ans;
    }

    private void PlaceQueen(bool[,] chessboard, int row){
        var n = chessboard.GetLength(0);
        
        if(row == n){
            AddAnswer(chessboard);
            return;
        }

        for(var col=0; col<n; col++){
            if(!CanPlace(chessboard, row, col))
                continue;

            var diag = n + row - col;
            var antiDiag = row + col;

            chessboard[row,col] = true;
            colQueen |= (1 << col);
            diagQueen |= (1 << diag);
            antiDiagQueen |= (1 << antiDiag);
            
            PlaceQueen(chessboard, row+1);

            antiDiagQueen ^= (1 << antiDiag);
            diagQueen ^= (1 << diag);
            colQueen ^= (1 << col);
            chessboard[row,col] = false;
        }
    }

    private bool CanPlace(bool[,] chessboard, int x , int y){
        var diag = chessboard.GetLength(0) + x - y;
        var antiDiag = x + y;

        if((colQueen & (1 << y)) != 0) return false;
        if((diagQueen & (1 << diag)) != 0) return false;
        if((antiDiagQueen & (1 << antiDiag)) != 0) return false;

        return true;
    }

    private void AddAnswer(bool[,] chessboard){
        var n = chessboard.GetLength(0);
        var rowList = new List<string>();

        for(var row=0; row < n; row++){
            var sb = new StringBuilder();
            for(var col=0; col < n; col++){
                if(chessboard[row,col])
                    sb.Append("Q");
                else
                    sb.Append(".");
            }
            rowList.Add(sb.ToString());
        }

        ans.Add(rowList);
    }
}

// Accepted - using array to track col and both diagonals
public class SolutionArr {
    IList<IList<string>> ans;
    bool[] colQueen, diagQueen, antiDiagQueen;

    public IList<IList<string>> SolveNQueens(int n) {
        var chessboard = new bool[n,n];
        ans = new List<IList<string>>();

        colQueen = new bool[n];
        diagQueen = new bool[1 + n*n];
        antiDiagQueen = new bool[1 + n*n];
        
        PlaceQueen(chessboard, 0);
        return ans;
    }

    private void PlaceQueen(bool[,] chessboard, int row){
        var n = chessboard.GetLength(0);
        
        if(row == n){
            AddAnswer(chessboard);
            return;
        }

        for(var col=0; col<n; col++){
            if(!CanPlace(chessboard, row, col))
                continue;

            var diag = n + row - col;
            var antiDiag = row + col;

            chessboard[row,col] = true;
            colQueen[col] = true;    
            diagQueen[diag] = true;
            antiDiagQueen[antiDiag] = true;
            
            PlaceQueen(chessboard, row+1);

            antiDiagQueen[antiDiag] = false;
            diagQueen[diag] = false;
            colQueen[col] = false;
            chessboard[row,col] = false;
        }
    }

    private bool CanPlace(bool[,] chessboard, int x , int y){
        var diag = chessboard.GetLength(0) + x - y;
        var antiDiag = x + y;

        if(colQueen[y] || diagQueen[diag] || antiDiagQueen[antiDiag]) return false;
        return true;
    }

    private void AddAnswer(bool[,] chessboard){
        var n = chessboard.GetLength(0);
        var rowList = new List<string>();

        for(var row=0; row < n; row++){
            var sb = new StringBuilder();
            for(var col=0; col < n; col++){
                if(chessboard[row,col])
                    sb.Append("Q");
                else
                    sb.Append(".");
            }
            rowList.Add(sb.ToString());
        }

        ans.Add(rowList);
    }
}