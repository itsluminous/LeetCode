public class Solution {
    public int MyAtoi(string s) {
        long ans = 0;
        var sign = 1;
        var numStarted = false;

        s = s.Trim();
        foreach(var ch in s){
            if(ch == '-' && !numStarted){
                sign = -1;
                numStarted = true;
                continue;
            }

            if(ch == '+' && !numStarted){
                numStarted = true;
                continue;
            }

            if(ch < '0' || ch > '9') break; // break at first non-digit char

            ans = (10 * ans) + (ch - '0');
            numStarted = true;

            // check out of bounds
            if(sign == -1 && sign * ans < int.MinValue){
                ans = int.MinValue;
                break;
            }
            if(sign == 1 && sign * ans > int.MaxValue){
                ans = int.MaxValue;
                break;
            }
        }

        return (int)(sign * ans);
    }
}