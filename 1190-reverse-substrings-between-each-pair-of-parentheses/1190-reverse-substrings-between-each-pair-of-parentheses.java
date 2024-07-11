// O(n)
class Solution {
    public String reverseParentheses(String s) {
        var n = s.length();
        var stack = new Stack<Integer>();
        var pair = new int[n];  // index which has open bracket, will have index of closing bracket as value

        for(var idx=0; idx<n; idx++){
            if(s.charAt(idx) == '(')
                stack.push(idx);
            else if(s.charAt(idx) == ')'){
                var open = stack.pop();
                pair[idx] = open;
                pair[open] = idx;
            }
        }

        var sb = new StringBuilder();
        for(int idx=0, dir=1; idx<n; idx += dir){
            if(s.charAt(idx) == '(' || s.charAt(idx) == ')'){
                idx = pair[idx];
                dir = -dir;
            }
            else
                sb.append(s.charAt(idx));
        }

        return sb.toString();
    }
}

// Accepted - using stack O(n^2)
class SolutionStack {
    public String reverseParentheses(String s) {
        var stack = new Stack<StringBuilder>();

        var sb = new StringBuilder();
        for(var ch : s.toCharArray()){
            if(ch == '('){
                stack.push(sb);
                sb = new StringBuilder();
            }
            else if(ch == ')'){
                var rev = sb.reverse();
                sb = stack.pop().append(rev);
            }
            else
                sb.append(ch);
        }

        return sb.toString();
    }
}