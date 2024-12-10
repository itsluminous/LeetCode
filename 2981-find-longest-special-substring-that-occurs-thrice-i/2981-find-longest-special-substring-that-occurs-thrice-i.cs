public class Solution {
    public int MaximumLength(string s) {
        // frequency of each string of a len with a repeated char
        var count = new Dictionary<(char, int), int>();
        int n = s.Length, len = 0;

        for(var start=0; start<n; start++){
            var ch = s[start];
            len = 0;
            for(var end=start; end < n; end++){
                if(ch == s[end]){
                    len++;
                    if(count.ContainsKey((ch, len)))
                        count[(ch, len)]++;
                    else 
                        count[(ch, len)] = 1;
                }
                else
                    break;
            }
        }

        var ans = 0;
        foreach(var (ch, ln) in count.Keys){
            if(count[(ch, ln)] >= 3 && ln > ans)
                ans = ln;
        }

        return ans == 0 ? -1 : ans;
    }
}