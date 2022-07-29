public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var result = new List<string>();
        var n = pattern.Length;
        
        foreach(var word in words){
            if(word.Length != n) continue;
            var patdict = new Dictionary<char, char>();    // pattern -> char
            var chardict = new Dictionary<char, char>();   // char -> pattern
            var i = 0;
            
            for(i=0; i<n; i++){
                char ch = word[i], pat = pattern[i];
                if(!patdict.ContainsKey(pat)) patdict[pat] = ch;
                if(!chardict.ContainsKey(ch)) chardict[ch] = pat;
                if(patdict[pat] != ch || chardict[ch] != pat) break;
            }
            if(i == n) result.Add(word);
        }
        
        return result;
    }
}