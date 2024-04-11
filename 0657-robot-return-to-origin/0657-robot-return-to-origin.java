public class Solution {
    public boolean judgeCircle(String moves) {
        int x = 0, y = 0;
        for(var move : moves.toCharArray()){
            if(move == 'R') x++;
            else if(move == 'L') x--;
            else if(move == 'U') y--;
            else if(move == 'D') y++;
        }
        return x == 0 && y == 0;
    }
}