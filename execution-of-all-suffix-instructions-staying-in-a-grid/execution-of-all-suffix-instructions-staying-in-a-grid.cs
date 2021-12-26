// O(n^2), but there exists O(m) solution
public class Solution {
    public int[] ExecuteInstructions(int n, int[] startPos, string s) {
        var len = s.Length;
        var result = new int[len];
        for(var start=0; start<len; start++){
            int x=startPos[0], y=startPos[1], count=0;
            for(var i=start; i<len; i++){
                if(s[i] == 'L' && y == 0) break;
                else if(s[i] == 'L') y--;
                else if(s[i] == 'R' && y == n-1) break;
                else if(s[i] == 'R') y++;
                else if(s[i] == 'D' && x == n-1) break;
                else if(s[i] == 'D') x++;
                else if(s[i] == 'U' && x == 0) break;
                else if(s[i] == 'U') x--;
                count++;
            }
            result[start] = count;
        }
        
        return result;
    }
}