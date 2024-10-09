class Solution {
    public int minAddToMakeValid(String s) {
        int open = 0, close = 0;
        for(var ch : s.toCharArray()){
            if(ch == '(') open++;
            else if(open > 0) open--;
            else close++;
        }

        // we will have to balance leftover open & close brackets
        return open + close;
    }
}