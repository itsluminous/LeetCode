public class Solution {
    public bool JudgeCircle(string moves) {
        int x = 0, y = 0;
        foreach(var move in moves){
            if(move == 'R') x++;
            else if(move == 'L') x--;
            else if(move == 'U') y--;
            else if(move == 'D') y++;
        }
        return x == 0 && y == 0;
    }
}

// Accepted, using dictionary
public class SolutionDict {
    public bool JudgeCircle(string moves) {
        int x = 0, y = 0;
        var dir = new Dictionary<char, int[]>{
            {'R', new []{1, 0}},
            {'L', new []{-1, 0}},
            {'U', new []{0, -1}},
            {'D', new []{0, 1}}
        };

        foreach(var move in moves){
            x += dir[move][0];
            y += dir[move][1];
        }

        return x == 0 && y == 0;
    }
}