// O(n)
public class Solution {
    public string ReverseParentheses(string s) {
        var n = s.Length;
        var stack = new Stack<int>();
        var pair = new int[n];  // index which has open bracket, will have index of closing bracket as value

        for(var idx=0; idx<n; idx++){
            if(s[idx] == '(')
                stack.Push(idx);
            else if(s[idx] == ')'){
                var open = stack.Pop();
                pair[idx] = open;
                pair[open] = idx;
            }
        }

        var sb = new StringBuilder();
        for(int idx=0, dir=1; idx<n; idx += dir){
            if(s[idx] == '(' || s[idx] == ')'){
                idx = pair[idx];
                dir = -dir;
            }
            else
                sb.Append(s[idx]);
        }

        return sb.ToString();
    }
}

// Accepted - using stack O(n^2)
public class SolutionStack {
    public string ReverseParentheses(string s) {
        var stack = new Stack<StringBuilder>();

        var sb = new StringBuilder();
        foreach(var ch in s){
            if(ch == '('){
                stack.Push(sb);
                sb = new StringBuilder();
            }
            else if(ch == ')'){
                var rev = sb.ToString().Reverse().ToArray();
                sb = stack.Pop().Append(rev);
            }
            else
                sb.Append(ch);
        }

        return sb.ToString();
    }
}