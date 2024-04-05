public class Solution {
    public string MakeGood(string s) {
        var stack = new Stack<char>();
        foreach(var ch in s){
            if(stack.Count > 0 && Math.Abs(stack.Peek() - ch) == 32)
                stack.Pop();
            else
                stack.Push(ch);
        }

        var len = stack.Count;
        if(len == 0) return String.Empty;

        var result = new char[len];
        for(var i=len-1; i>=0; i--)
            result[i] = stack.Pop();

        return new String(result);
    }
}