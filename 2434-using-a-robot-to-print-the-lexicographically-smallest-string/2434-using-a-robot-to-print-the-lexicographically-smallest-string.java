class Solution {
    public String robotWithString(String s) {
        var ss = s.toCharArray();

        var freq = new int[123];    // ascii of z is 122
        for(var ch : ss) freq[ch]++;

        var ans = new StringBuilder();
        var stack = new Stack<Character>();

        for(var ch : ss){
            stack.push(ch);
            freq[ch]--;

            // find out smallest available char in s
            var c = 'a';
            while(c <= 'z' && freq[c] == 0) c++;

            // while stack is <= remaining min character, pop to ans
            while(!stack.isEmpty() && (c == 'z' || stack.peek() <= c))
                ans.append(stack.pop());
        }

        // append remaining characters from stack
        while(!stack.isEmpty()) ans.append(stack.pop());

        return ans.toString();
    }
}