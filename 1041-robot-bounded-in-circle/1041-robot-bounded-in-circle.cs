// The robot stays in the circle only if at the end it doesn't stay pointing north, or it returns to home.
public class Solution {
    public bool IsRobotBounded(string instructions) {
        var (x,y) = (0,0);
        (int x, int y)[] dirs = new []{(0,1), (1,0), (0,-1), (-1, 0)};
        var dirIdx = 0;

        foreach(var dir in instructions){
            if(dir == 'G'){
                x += dirs[dirIdx].x;
                y += dirs[dirIdx].y;
            }
            else if(dir == 'L')
                dirIdx = (dirIdx+3) % 4;
            else if(dir == 'R')
                dirIdx = (dirIdx+1) % 4;
        }

        if((x|y) == 0) return true;  // robot returned to home
        return dirIdx > 0;           // any direction except north facing will lead to cycle eventually
    }
}