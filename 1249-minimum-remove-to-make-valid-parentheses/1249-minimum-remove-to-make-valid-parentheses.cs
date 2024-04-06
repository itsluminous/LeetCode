public class Solution {
    public string MinRemoveToMakeValid(string s) {
        var n = s.Length;
        var stack = new Stack<int>();
        var removeIdx = new bool[n];

        for(var i=0; i<n; i++){
            if(s[i] == '(')
                stack.Push(i);
            else if(s[i] == ')' && stack.Count > 0)
                stack.Pop();
            else if(s[i] == ')')
                removeIdx[i] = true;
        }

        while(stack.Count > 0)
            removeIdx[stack.Pop()] = true;

        var sb = new StringBuilder();
        for(var i=0; i<n; i++){
            if(removeIdx[i]) continue;
            sb.Append(s[i]);
        }

        return sb.ToString();
    }
}