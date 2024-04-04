// maxDepth is going to be max open brackets at any time
public class Solution {
    public int maxDepth(String s) {
        int maxDepth = 0, openBrackets = 0;
        
        for(var ch : s.toCharArray()){
            if(ch == '(') openBrackets++;
            else if(ch == ')') openBrackets--;

            maxDepth = Math.max(maxDepth, openBrackets);
        }

        return maxDepth;
    }
}