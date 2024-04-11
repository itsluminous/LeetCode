public class Solution {
    public String removeKdigits(String num, int k) {
        int n = num.length(), i = 0;
        if(n == k) return "0";    // if both are same length then result will be 0

        var chars = num.toCharArray();
        var stack = new Stack<Character>();
        while(i < n){
            // store only the smaller digit on top of stack
            while(k > 0 && stack.size() > 0 && stack.peek() > chars[i]){
                stack.pop();
                k--;
            }

            // don't add "0" as first digit in stack, because it has no value
            if(stack.size() == 0 && chars[i] == '0') i++;
            else stack.push(chars[i++]);
        }

        // if k is not 0, remove last k elements (for case like "12345" or "11111")
        while(k > 0 && stack.size() > 0){
            stack.pop();
            k--;
        }

        n = stack.size();
        if(n == 0) return "0";

        var ans = new char[n];
        for(i=n-1; i>=0; i--) ans[i] = stack.pop();

        return new String(ans);
    }
}