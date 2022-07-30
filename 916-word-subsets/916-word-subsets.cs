public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var result = new List<string>();
        
        // merge all words in words2 into one
        var w2 = new int[26];
        foreach(var word in words2){
            var dict = new Dictionary<char,int>();
            foreach(var ch in word){
                if(!dict.ContainsKey(ch)) dict[ch] = 1;
                else dict[ch]++;
                
                w2[ch-'a'] = Math.Max(w2[ch-'a'], dict[ch]);    // keep max count of any char
            }
        }
        
        // compare each word in words1 against the merged words2
        foreach(var word in words1){
            var clone = (int[]) w2.Clone();     // clone so that we don't modify original array
            foreach(var ch in word){
                if(clone[ch-'a'] == 0) continue;    // it means this char is not needed in words2
                clone[ch-'a']--;
            }
            
            // if we found all chars from words2, then add it to result
            if(clone.Sum() == 0) result.Add(word);  
        }
        
        return result;
    }
}