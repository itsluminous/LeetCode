public class Solution {
    public int CountPalindromicSubsequence(string s) {
        var n = s.Length;
        int[] first = new int[26], last = new int[26];
        Array.Fill(first, n);

        for(var i = 0; i < n; i++) {
            char ch = s[i];
            first[ch - 'a'] = Math.Min(first[ch - 'a'], i);
            last[ch - 'a'] = i;
        }

        var ans = 0;
        for(var i = 0; i < 26; i++) {
            if(first[i] + 1 < last[i]) {
                var uniqueChars = new HashSet<char>();
                for (var j = first[i] + 1; j < last[i]; j++)
                    uniqueChars.Add(s[j]);
                ans += uniqueChars.Count;
            }
        }

        return ans;
    }
}