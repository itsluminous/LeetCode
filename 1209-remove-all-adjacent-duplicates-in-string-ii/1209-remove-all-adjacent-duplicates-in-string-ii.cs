public class Solution {
    public string RemoveDuplicates(string s, int k) {
        Stack<(char ch, int freq)> stack = new Stack<(char, int)>();
        foreach(var c in s){
            if(stack.Count > 0 && stack.Peek().ch == c){
                var top = stack.Pop();
                top.freq++;
                
                if(top.freq != k)       // if freq == k then drop this substring
                    stack.Push(top);
            }
            else
                stack.Push((c, 1));
        }
        
        var sb = new StringBuilder();
        while(stack.Count > 0){
            var top = stack.Pop();
            sb.Append(top.ch, top.freq);
        }
        
        return new string(sb.ToString().Reverse().ToArray());   // reverse the stringbuilder
    }
}