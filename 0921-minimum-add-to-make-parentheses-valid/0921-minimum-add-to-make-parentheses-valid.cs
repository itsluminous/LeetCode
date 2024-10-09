public class Solution {
    public int MinAddToMakeValid(string s) {
        int open = 0, close = 0;
        foreach(var ch in s){
            if(ch == '(') open++;
            else if(open > 0) open--;
            else close++;
        }

        // we will have to balance leftover open & close brackets
        return open + close;
    }
}