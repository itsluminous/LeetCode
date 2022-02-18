public class Solution {
    public string RemoveKdigits(string num, int k) {
        var len = num.Length;
        if(len == k) return "0";    // if both are same length then result will be 0
        
        var stack = new Stack<char>();
        var idx = 0;
        while(idx < len){
            //whenever meet a digit which is less than the previous digit, discard the previous one
            while(k > 0 && stack.Count > 0 && stack.Peek() > num[idx]){
                stack.Pop();
                k--;
            }
            
            stack.Push(num[idx]);
            idx++;
        }
        
        // case like "1111" and "12345" - here remove last k digits
        while(k>0){
            stack.Pop();
            k--;            
        }
        
        // construct the number now
        var sb = new StringBuilder();
        while(stack.Count > 0) sb.Append(stack.Pop());
        
        //remove all the 0 at the end (which will become head later)
        while(sb.Length > 1 && sb[sb.Length-1] == '0') sb.Length--;
        
        return new string(sb.ToString().Reverse().ToArray());
    }
}