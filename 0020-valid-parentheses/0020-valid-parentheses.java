class Solution {
    public boolean isValid(String s) {
        var stack = new Stack<Character>();
        for(var ch : s.toCharArray()){
            if(ch == '(' || ch == '{' || ch == '[')
                stack.push(ch);
            else if(ch == ')' && !stack.isEmpty() && stack.peek() == '(')
                stack.pop();
            else if(ch == '}' && !stack.isEmpty() && stack.peek() == '{')
                stack.pop();
            else if(ch == ']' && !stack.isEmpty() && stack.peek() == '[')
                stack.pop();
            else
                return false;
        }
        return stack.isEmpty();
    }
}