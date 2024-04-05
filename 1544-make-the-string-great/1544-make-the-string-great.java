public class Solution {
    public String makeGood(String s) {
        var stack = new Stack<Character>();
        for(var ch : s.toCharArray()){
            if(stack.size() > 0 && Math.abs(stack.peek() - ch) == 32)
                stack.pop();
            else
                stack.push(ch);
        }

        var len = stack.size();
        if(len == 0) return "";

        var result = new char[len];
        for(var i=len-1; i>=0; i--)
            result[i] = stack.pop();

        return new String(result);
    }
}