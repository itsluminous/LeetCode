public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        // find max freq of each char from words2
        var freq = new int[26];
        foreach(var word in words2){
            var map = new Dictionary<char, int>();
            foreach(var ch in word){
                if((map.ContainsKey(ch))) map[ch]++;
                else map[ch] = 1;
                
                // update the freq of curr char
                freq[ch-'a'] = Math.Max(freq[ch-'a'], map[ch]);
            }
        }

        // find words which satisfy all conditions of freq
        var ans = new List<string>();
        foreach(var word in words1){
            var frq = (int[])freq.Clone();
            foreach(var ch in word){
                if(frq[ch-'a'] == 0) continue;  // this char is not needed
                frq[ch-'a']--;
            }

            // check if all chars were covered
            if(frq.Sum() == 0) ans.Add(word);
        }

        return ans;
    }
}