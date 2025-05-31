public class Solution {
    public int SnakesAndLadders(int[][] board) {
        var n = board.Length;
        var dest = n*n;
        var visited = new bool[dest+1];
        var cellToIdxMap = GetCellToIdxMap(n);

        var queue = new Queue<int>();
        queue.Enqueue(1);
        visited[1] = true;

        for(var rolls = 0; queue.Count > 0; rolls++){
            for(var i=queue.Count; i>0; i--){
                var cell = queue.Dequeue();
                if(cell == dest) return rolls;

                for(var next=cell+1; next <= Math.Min(cell+6, dest); next++){     
                    int x = cellToIdxMap[next][0], y = cellToIdxMap[next][1];
                    var actualNext = next;
                    if(board[x][y] != -1) actualNext = board[x][y];
                    if(visited[actualNext]) continue;
                    
                    queue.Enqueue(actualNext);
                    visited[actualNext] = true;
                }
            }
        }
        return -1;
    }

    private int[][] GetCellToIdxMap(int n){
        var cellToIdxMap = new int[n * n + 1][];
        var cell = 1;
        var leftToRight = true;

        for(var r=n-1; r >= 0; r--){
            if(leftToRight)
                for (int c = 0; c < n; c++)
                    cellToIdxMap[cell++] = [r, c];
            else
                for (int c = n - 1; c >= 0; c--)
                    cellToIdxMap[cell++] = [r, c];
            leftToRight = !leftToRight; // reverse the col direction
        }

        return cellToIdxMap;
    }
}