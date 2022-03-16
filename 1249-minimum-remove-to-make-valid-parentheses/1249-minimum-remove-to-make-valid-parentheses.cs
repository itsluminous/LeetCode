public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var n = s.Length;
        var removeIdx = new bool[n];
        var stack = new Stack<int>();
        
        // find all closing brackets which are extra
        for(var i=0; i<n; i++){
            var ch = s[i];
            if(ch == '(')
                stack.Push(i);
            else if(ch == ')' && stack.Count > 0)
                stack.Pop();
            else if(ch == ')' && stack.Count == 0)
                removeIdx[i] = true;
        }
        
        // all opening brackets left in stack are extra
        var st = stack.Count;
        for(var i=0; i<st; i++){
            var idx = stack.Pop();
            removeIdx[idx] = true;
        }
        
        // create final string without extra brackets
        var sb = new StringBuilder();
        for(var i=0; i<n; i++){
            if(!removeIdx[i])
                sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
}