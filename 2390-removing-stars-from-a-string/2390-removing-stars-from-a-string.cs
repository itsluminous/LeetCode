public class Solution {
    public string RemoveStars(string s) {
        var stack = new List<char>();
        foreach(var ch in s)
            if(ch == '*') stack.RemoveAt(stack.Count-1);
            else stack.Add(ch);
        return string.Join("", stack);
    }
}