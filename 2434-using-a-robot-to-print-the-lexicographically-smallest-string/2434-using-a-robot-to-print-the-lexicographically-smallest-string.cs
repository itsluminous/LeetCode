public class Solution {
    public string RobotWithString(string s) {
        var freq = new int[123];    // ascii of z is 122
        foreach(var ch in s) freq[ch]++;

        var ans = new StringBuilder();
        var stack = new Stack<char>();

        foreach(var ch in s){
            stack.Push(ch);
            freq[ch]--;

            // find out smallest available char in s
            var c = 'a';
            while(c <= 'z' && freq[c] == 0) c++;

            // while stack is <= remaining min character, pop to ans
            while(stack.Count > 0 && (c == 'z' || stack.Peek() <= c))
                ans.Append(stack.Pop());
        }

        // append remaining characters from stack
        while(stack.Count > 0) ans.Append(stack.Pop());

        return ans.ToString();
    }
}