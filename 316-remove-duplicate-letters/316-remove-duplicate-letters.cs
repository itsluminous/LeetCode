public class Solution {
    public string RemoveDuplicateLetters(string s) {
        var count = new int[26];    // count of occurence of each char
        var visited = new bool[26]; // track if we have processed this char
        var stack = new Stack<char>();
        
        foreach(var ch in s)
            count[ch-'a']++;
        
        foreach(var ch in s){
            count[ch-'a']--;
            if(visited[ch-'a']) continue;
            
            //if current character is smaller than last character in stack which occurs later in the string again
            //it can be removed and  added later e.g stack = bc remaining string abc then a can pop b and then c
            while(stack.Count > 0 && ch < stack.Peek() && count[stack.Peek() - 'a'] > 0)
                visited[stack.Pop() - 'a'] = false;
            
            stack.Push(ch);
            visited[ch-'a'] = true;
        }
        
        var sb = new StringBuilder();
        while(stack.Count > 0)
            sb.Append(stack.Pop());
        
        // the result will be reverse of stack
        return new string(sb.ToString().Reverse().ToArray());
    }
}