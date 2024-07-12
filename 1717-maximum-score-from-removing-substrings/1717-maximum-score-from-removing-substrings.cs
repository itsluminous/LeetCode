public class Solution {
    int points = 0;

    public int MaximumGain(string s, int x, int y) {
        var bigger = x > y ? "ab" : "ba";
        var smaller = bigger == "ab" ? "ba" : "ab";
        var pointmap = new Dictionary<string, int>{{"ab", x}, {"ba", y}};

        s = Match(s, bigger, pointmap[bigger]);
        Match(s, smaller, pointmap[smaller]);

        return points;
    }

    private string Match(string s, string target, int point){
        var stack = new Stack<char>();
        foreach(var ch in s){
            if(ch == target[1] && stack.Count > 0 && stack.Peek() == target[0]){
                stack.Pop();
                points += point;
            }
            else
                stack.Push(ch);
        }

        var sb = new StringBuilder();
        while(stack.Count > 0)
            sb.Append(stack.Pop());
        return new string(sb.ToString().Reverse().ToArray());
    }
}