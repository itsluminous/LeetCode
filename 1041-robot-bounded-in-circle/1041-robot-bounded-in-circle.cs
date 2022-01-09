// The robot stays in the circle only if at the end it doesn't stay pointing north, or it returns to home.
public class Solution {
    public bool IsRobotBounded(string instructions) {
        int x = 0, y = 0, dir = 0;
        var directions = new []{new []{0,1}, new []{-1,0}, new []{0,-1}, new []{1,0}};  // N, W, S, E
        
        foreach(var inst in instructions){
            if(inst == 'L')
                dir = (dir+1)%4;
            else if(inst == 'R')
                dir = (dir+3)%4;
            else{    // 'G'
                x += directions[dir][0];
                y += directions[dir][1];
            }
        }
        
        if((x == 0 && y == 0) || dir != 0) return true;
        return false;
    }
}