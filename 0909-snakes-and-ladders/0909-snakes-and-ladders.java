class Solution {
    public int snakesAndLadders(int[][] board) {
        var n = board.length;
        var dest = n*n;
        var visited = new boolean[dest+1];
        var cellToIdxMap = getCellToIdxMap(n);

        Queue<Integer> queue = new LinkedList<>();
        queue.offer(1);
        visited[1] = true;

        for(var rolls = 0; !queue.isEmpty(); rolls++){
            for(var i=queue.size(); i>0; i--){
                var cell = queue.poll();
                if(cell == dest) return rolls;

                for(var next=cell+1; next <= Math.min(cell+6, dest); next++){     
                    int x = cellToIdxMap[next][0], y = cellToIdxMap[next][1];
                    var actualNext = next;
                    if(board[x][y] != -1) actualNext = board[x][y];
                    if(visited[actualNext]) continue;
                    
                    queue.offer(actualNext);
                    visited[actualNext] = true;
                }
            }
        }
        return -1;
    }

    private int[][] getCellToIdxMap(int n){
        var cellToIdxMap = new int[n * n + 1][2];
        var cell = 1;
        var leftToRight = true;

        for(var r=n-1; r >= 0; r--){
            if(leftToRight)
                for (int c = 0; c < n; c++)
                    cellToIdxMap[cell++] = new int[]{r, c};
            else
                for (int c = n - 1; c >= 0; c--)
                    cellToIdxMap[cell++] = new int[]{r, c};
            leftToRight = !leftToRight; // reverse the col direction
        }

        return cellToIdxMap;
    }
}