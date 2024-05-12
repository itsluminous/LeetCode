public class Solution {
    public int FindPermutationDifference(string s, string t) {
        var pos = new int[26];
        for(var i=0; i<s.Length; i++)
            pos[s[i]-'a'] = i;
        
        var ans = 0;
        for(var i=0; i<t.Length; i++)
            ans += Math.Abs(pos[t[i]-'a'] - i);
        
        return ans;
    }
}