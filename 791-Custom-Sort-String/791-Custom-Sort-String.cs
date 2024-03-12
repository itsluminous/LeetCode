public class Solution {
    public string CustomSortString(string order, string s) {
        var ans = new StringBuilder();
        var n = order.Length;

        // figure out frequency of each char in s
        var freq = new int[26];
        foreach(var ch in s)
            freq[ch-'a']++;

        // for each char in order, figure out order in s
        for(var i=0; i<n; i++){
            var ch = order[i];
            var idx = ch-'a';
            if(freq[idx] == 0) continue;

            // handle the chars in s
            do{
                ans.Append(ch);
                freq[idx]--;
            }while(freq[idx] > 0);

            // handle the chars in order
            do{
                i++;
            }while(i<n && order[i] == ch);
            if(i<n) i--;
        }

        // append all the remaining chars from s
        for(var i=0; i<26; i++)
            ans.Append(Convert.ToChar('a'+i), freq[i]);

        return ans.ToString();
    }
}