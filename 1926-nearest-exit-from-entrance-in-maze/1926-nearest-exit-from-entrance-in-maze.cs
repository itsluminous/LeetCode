public class Solution {
    public int NearestExit(char[][] maze, int[] entrance) {
        int m = maze.Length, n = maze[0].Length;
        var queue = new Queue<(int, int)>();    // x,y coordinates will be stored in queue

        var (startx, starty) = (entrance[0], entrance[1]);
        queue.Enqueue((startx, starty));

        for(var steps=0; queue.Count > 0; steps++){
            for(var i=queue.Count; i>0; i--){
                var (x,y) = queue.Dequeue();
                if(x == -1 || y == -1 || x == m || y == n || maze[x][y] == '+') continue;
                if(FoundExit(m, n, x, y, startx, starty)) return steps;
                
                // mark current cell as visited & add next 4 possible directions
                maze[x][y] = '+';
                queue.Enqueue((x+1, y));
                queue.Enqueue((x-1, y));
                queue.Enqueue((x, y+1));
                queue.Enqueue((x, y-1));
            }
        }

        return -1;
    }

    private bool FoundExit(int m, int n, int x, int y, int startx, int starty){
        if(x == startx && y == starty) return false;
        if(x == 0 || y == 0 || x == m-1 || y == n-1) return true;
        return false;
    }
}