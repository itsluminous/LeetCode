class Solution {
    public int myAtoi(String s) {
        long ans = 0;
        var sign = 1;
        var numStarted = false;

        var ss = s.trim().toCharArray();
        for(var ch : ss){
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
            if(sign == -1 && sign * ans < Integer.MIN_VALUE){
                ans = Integer.MIN_VALUE;
                break;
            }
            if(sign == 1 && sign * ans > Integer.MAX_VALUE){
                ans = Integer.MAX_VALUE;
                break;
            }
        }

        return (int)(sign * ans);
    }
}