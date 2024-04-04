// maxDepth is going to be max open brackets at any time
public class Solution {
    public int MaxDepth(string s) {
        int maxDepth = 0, openBrackets = 0;
        
        foreach(var ch in s){
            if(ch == '(') openBrackets++;
            else if(ch == ')') openBrackets--;

            maxDepth = Math.Max(maxDepth, openBrackets);
        }

        return maxDepth;
    }
}