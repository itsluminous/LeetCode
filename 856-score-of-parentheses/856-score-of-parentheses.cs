public class Solution {
    public int ScoreOfParentheses(string s) {
        var stack = new Stack<int>();
        stack.Push(0);  // current score
        
        foreach(char ch in s){
            if(ch == '(')
                stack.Push(0);
            else{
                var curr = stack.Pop();
                var prev = stack.Pop();
                var val = prev + Math.Max(2*curr, 1);   // if curr = 0, then we should use 1
                stack.Push(val);
            }
        }
        
        return stack.Pop();
    }
}