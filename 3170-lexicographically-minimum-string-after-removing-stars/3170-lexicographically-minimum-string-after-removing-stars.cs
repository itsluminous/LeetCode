public class Solution {
    public string ClearStars(string s) {
        var n = s.Length;
        var removed = new bool[n];  // to track which indexes are removed from final ans

        // pos will track which all indexes have characters 'a' to 'z'
        var pos = new Stack<int>[26];
        for(var i=0; i<26; i++) pos[i] = new Stack<int>();

        for(var i=0; i<n; i++){
            if(s[i] != '*')
                pos[s[i] - 'a'].Push(i);    // found non '*' char, so save its pos
            else {
                removed[i] = true;          // mark '*' as removed
                // find out the smallest character that can be removed
                for(var ch = 'a'; ch <= 'z'; ch++){
                    if(pos[ch-'a'].Count == 0) continue;
                    var idx = pos[ch-'a'].Pop();    // remove max idx of smallest character
                    removed[idx] = true;
                    break;
                }
            }
        }

        // any idx not marked for removal will be in ans
        var ans = new StringBuilder();
        for(var i=0; i<n; i++)
            if(!removed[i]) ans.Append(s[i]);
        
        return ans.ToString();
    }
}