public class Solution {
    public IList<string> CommonChars(string[] words) {
        // count occurrence of all chars in first word
        var prev = new int[26];
        foreach(var ch in words[0])
            prev[ch-'a']++;
        
        // count occurrence of all common chars in other strings
        for(var i=1; i < words.Length; i++){
            var curr = new int[26];
            foreach(var ch in words[i])
                curr[ch-'a'] = Math.Min(prev[ch-'a'], curr[ch-'a'] + 1);
            prev = curr;
        }

        // find all chars that are common, along with frequency
        var ans = new List<string>();
        for(var i=0; i<26; i++)
            for(var j=0; j<prev[i]; j++)
                ans.Add(char.ConvertFromUtf32('a' + i));
        
        return ans;
    }
}