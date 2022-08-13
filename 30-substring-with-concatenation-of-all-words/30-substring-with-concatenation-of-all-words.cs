public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        // create dictionary of words and their count
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
            var dict = map.ToDictionary(entry => entry.Key, entry => entry.Value);  // clone dict
            do{
                var word = s.Substring(i, wordlen);
                if(dict.ContainsKey(word) && dict[word] > 0) dict[word]--;
                else break;
                
                i += wordlen;
            }while(i < l + substrlen);
            
            // if we found all words, then this index can be part of ans
            if(i >= l + substrlen) result.Add(l);
        }
        
        return result;
    }
}