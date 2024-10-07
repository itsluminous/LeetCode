public class Solution {
    public int MinLength(string s) {
        var stack = new Stack<char>();
        foreach(var ch in s){
            if(stack.Count == 0)
                stack.Push(ch);
            else if(stack.Peek() == 'A' && ch == 'B')
                stack.Pop();
            else if(stack.Peek() == 'C' && ch == 'D')
                stack.Pop();
            else
                stack.Push(ch);
        }
        return stack.Count;
    }
}