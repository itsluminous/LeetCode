public class Solution {
    public string RemoveKdigits(string num, int k) {
        int n = num.Length, i = 0;
        if(n == k) return "0";    // if both are same length then result will be 0

        var stack = new Stack<char>();
        while(i < n){
            // store only the smaller digit on top of stack
            while(k > 0 && stack.Count > 0 && stack.Peek() > num[i]){
                stack.Pop();
                k--;
            }

            // don't add "0" as first digit in stack, because it has no value
            if(stack.Count == 0 && num[i] == '0') i++;
            else stack.Push(num[i++]);
        }

        // if k is not 0, remove last k elements (for case like "12345" or "11111")
        while(k > 0 && stack.Count > 0){
            stack.Pop();
            k--;
        }

        n = stack.Count;
        if(n == 0) return "0";

        var ans = new char[n];
        for(i=n-1; i>=0; i--) ans[i] = stack.Pop();

        return new String(ans);
    }
}