public class Solution {
    private HashSet<string> seen = new HashSet<string>();
    private string ans;

    public string FindLexSmallestString(string s, int a, int b) {
        ans = s;
        DFS(s, a, b);
        return ans;
    }

    private void DFS(string s, int a, int b) {
        if(seen.Contains(s)) return;
        if(string.Compare(ans, s) > 0) ans = s;
        seen.Add(s);
        DFS(Add(s, a), a, b);
        DFS(Rotate(s, b), a, b);
    }

    private string Add(string s, int a) {
        var sb = new StringBuilder();
        for(var i = 0; i < s.Length; i++) {
            if ((i & 1) == 0) sb.Append(s[i]);
            else sb.Append((s[i] - '0' + a) % 10);
        }
        return sb.ToString();
    }

    private string Rotate(string s, int b) {
        var n = s.Length;
        return s.Substring(n - b) + s.Substring(0, n - b);
    }
}