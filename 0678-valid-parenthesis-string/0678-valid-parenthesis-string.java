public class Solution {
    public boolean checkValidString(String s) {
        int openMax = 0, openMin = 0;
        for(var ch : s.toCharArray()){
            if(ch == '('){
                openMax++;
                openMin++;
            }
            else if(ch == ')'){
                openMax--;
                openMin--;
            }
            else if(ch == '*'){
                openMax++;  // if * becomes '('
                openMin--;  // if * becomes ')'
            }

            openMin = Math.max(openMin, 0); // openMin cannot be negative
            if(openMax < 0) return false;   // not enough '(' to close parenthesis
            
        }

        return openMin == 0;
    }
}
