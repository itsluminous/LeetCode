public class Solution {
    public string ClearStars(string s) {
        var chars = new List<int>[26];  // list of indexes which have char i
        var indexes = new HashSet<int>();   // list of indexes which have not been removed
        for(var i=0; i<26; i++)
            chars[i] = new List<int>();

        for(var i=0; i<s.Length; i++){
            var ch = s[i];
            if(ch == '*'){
                for(var c=0; c<26; c++)
                    if(chars[c].Count > 0){
                        var idx = chars[c][chars[c].Count - 1];
                        chars[c].RemoveAt(chars[c].Count - 1);
                        indexes.Remove(idx);
                        break;
                    }
            }
            else{
                chars[ch-'a'].Add(i);
                indexes.Add(i);
            }
        }

        var ans = new StringBuilder();
        for(var i=0; i<s.Length; i++){
            var ch = s[i];
            if(indexes.Contains(i))
                ans.Append(ch);
        }

        return ans.ToString();
    }
}