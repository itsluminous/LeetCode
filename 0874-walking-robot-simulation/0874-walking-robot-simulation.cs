public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        var obs = new HashSet<string>();
        foreach(var ob in obstacles)
            obs.Add(ob[0] + ":" + ob[1]);

        (int x, int y)[] dirs = new []{(0, 1), (1, 0), (0, -1), (-1, 0)};
        int maxDist = 0, dirIdx = 0;
        int x = 0, y = 0;
        foreach(var cmd in commands){
            if(cmd == -1){
                dirIdx = (dirIdx + 1) % 4;
            }
            else if(cmd == -2){
                dirIdx--;
                if(dirIdx == -1) dirIdx = 3;
            }
            else{
                for(var i=0; i<cmd; i++){
                    int newX = x + dirs[dirIdx].x;
                    int newY = y + dirs[dirIdx].y;
                    if(obs.Contains(newX + ":" + newY)) break;
                    (x, y) = (newX, newY);
                }
                var currDist = x*x + y*y;
                maxDist = Math.Max(maxDist, currDist);
            }
        }

        return maxDist;
    }
}