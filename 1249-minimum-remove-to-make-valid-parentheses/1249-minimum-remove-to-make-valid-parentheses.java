public class Solution {
    public String minRemoveToMakeValid(String s) {
        var n = s.length();
        var stack = new Stack<Integer>();
        var removeIdx = new boolean[n];

        var chars = s.toCharArray();
        for(var i=0; i<n; i++){
            if(chars[i] == '(')
                stack.push(i);
            else if(chars[i] == ')' && stack.size() > 0)
                stack.pop();
            else if(chars[i] == ')')
                removeIdx[i] = true;
        }

        while(stack.size() > 0)
            removeIdx[stack.pop()] = true;

        var sb = new StringBuilder();
        for(var i=0; i<n; i++){
            if(removeIdx[i]) continue;
            sb.append(chars[i]);
        }

        return sb.toString();
    }
}