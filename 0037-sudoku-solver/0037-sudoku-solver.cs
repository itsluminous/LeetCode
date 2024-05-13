// Idea is to track the used numbers row-wise, col-wise & grid-wise  in bitmask
// 5,3,.,.,8,.,.,.,.  in a row will be represented as 010010100
public class Solution {
    public void SolveSudoku(char[][] board) {
        var row = new int[9];   // this will store bitmap for each row
        var col = new int[9];   // this will store bitmap for each col
        var grid = new int[9];  // bitmap for each grid
        var dots = new List<(int x, int y)>();  // to track all unsolved cells

        // fill up row map
        for(var i=0; i<9; i++)
            for(var j=0; j<9; j++)
                if(board[i][j] != '.'){
                    var num = board[i][j] - '0';
                    row[i] |=  (1 << num);
                }
                // track first unsolved cell
                else dots.Add((i,j));
                    
        
        if(dots.Count == 0) return;    // nothing to solve

        // fill up col map
        for(var i=0; i<9; i++)
            for(var j=0; j<9; j++)
                if(board[j][i] != '.'){
                    var num = board[j][i] - '0';
                    col[i] |=  (1 << num);
                }

        // fill up grid map
        for(var i=0; i<9; i++)
            for(var j=0; j<9; j++)
                if(board[i][j] != '.'){
                    var num = board[i][j] - '0';
                    var gridIdx = GetGridIdx(i, j);
                    grid[gridIdx] |=  (1 << num);
                }

        // start solving from first empty cell
        Solve(board, row, col, grid, dots, 0);
    }

    private bool Solve(char[][] board, int[] row, int[] col, int[] grid, List<(int, int)> dots, int idx){
        if(idx == dots.Count) return true;

        // try all numbers for curr index
        var (x,y) = dots[idx];
        var gridIdx = GetGridIdx(x,y);
        for(var num=1; num<=9; num++){
            var mask = (1 << num);

            // check if it is possible to set this number
            if((row[x] & mask) == mask || (col[y] & mask) == mask || (grid[gridIdx] & mask) == mask) continue;

            // set this value
            row[x] |= mask;
            col[y] |= mask;
            grid[gridIdx] |= mask;
            board[x][y] = (char)(num + '0');

            // fill up other empty places
            if(Solve(board, row, col, grid, dots, idx+1)) return true;

            // revert this value as it did not work
            row[x] ^= mask;
            col[y] ^= mask;
            grid[gridIdx] ^= mask;
            board[x][y] = '.';
        }

        return false;
    }

    private int GetGridIdx(int i, int j){
        // 0 1 2
        // 3 4 5
        // 6 7 8
        if(i <= 2 && j <= 2) return 0;
        if(i <= 2 && j <= 5) return 1;
        if(i <= 2) return 2;
        if(i <= 5 && j <= 2) return 3;
        if(i <= 5 && j <= 5) return 4;
        if(i <= 5) return 5;
        if(j <= 2) return 6;
        if(j <= 5) return 7;
        return 8;
    }
}