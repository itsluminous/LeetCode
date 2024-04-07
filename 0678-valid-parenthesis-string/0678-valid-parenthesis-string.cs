public class Solution {
    public bool CheckValidString(string s) {
        int openMax = 0, openMin = 0;
        foreach(var ch in s){
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

            openMin = Math.Max(openMin, 0); // openMin cannot be negative
            if(openMax < 0) return false;   // not enough '(' to close parenthesis
            
        }

        return openMin == 0;
    }
}
