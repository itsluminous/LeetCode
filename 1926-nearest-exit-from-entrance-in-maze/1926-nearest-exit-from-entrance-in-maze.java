public class Solution {
    public int nearestExit(char[][] maze, int[] entrance) {
        int m = maze.length, n = maze[0].length;
        Queue<int[]> queue = new LinkedList<>();    // x,y coordinates will be stored in queue
        queue.add(entrance);

        for(var steps=0; queue.size() > 0; steps++){
            for(var i=queue.size(); i>0; i--){
                var curr = queue.poll();
                if(curr[0] == -1 || curr[1] == -1 || curr[0] == m || curr[1] == n || maze[curr[0]][curr[1]] == '+') continue;
                if(foundExit(m, n, curr[0], curr[1], entrance[0], entrance[1])) return steps;
                
                // mark current cell as visited & add next 4 possible directions
                maze[curr[0]][curr[1]] = '+';
                queue.add(new int[]{curr[0]+1, curr[1]});
                queue.add(new int[]{curr[0]-1, curr[1]});
                queue.add(new int[]{curr[0], curr[1]+1});
                queue.add(new int[]{curr[0], curr[1]-1});
            }
        }

        return -1;
    }

    private boolean foundExit(int m, int n, int x, int y, int startx, int starty){
        if(x == startx && y == starty) return false;
        if(x == 0 || y == 0 || x == m-1 || y == n-1) return true;
        return false;
    }
}