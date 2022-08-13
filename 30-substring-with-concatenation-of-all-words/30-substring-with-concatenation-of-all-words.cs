public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        var map = new Dictionary<string, int>();
        foreach(var word in words){
            if(map.ContainsKey(word)) map[word]++;
            else map[word] = 1;
        }
        
        var result = new List<int>();
        var wordlen = words[0].Length;
        var substrlen = words.Length * wordlen;     // this will be sliding window length
        for(var l=0; l+substrlen <= s.Length; l++){
            var i = l;
            var dict = map.ToDictionary(entry => entry.Key, entry => entry.Value);
            do{
                var word = s.Substring(i, wordlen);
                if(dict.ContainsKey(word) && dict[word] > 0) dict[word]--;
                else break;
                
                i += wordlen;
            }while(i < l + substrlen);
            
            if(i >= l + substrlen) result.Add(l);
        }
        
        return result;
    }
}