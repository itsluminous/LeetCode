public class Solution {
    public string ReorganizeString(string s) {
        int n = s.Length, half = (n+1)/2;
        
        // count freq of each char
        var freq = new int[26];
        foreach(var ch in s){
            freq[ch-'a']++;
            if(freq[ch-'a'] > half) return string.Empty;
        }

        // arrange these chars in desc order based on freq count
        var list = new List<(char ch, int frq)>();
        for(var idx=0; idx<26; idx++){
            if(freq[idx] == 0) continue;
            list.Add(((char)('a' + idx), freq[idx]));
        }
        var sortedList = list.OrderByDescending(pair => pair.frq).ToList();

        // now build the ans
        var ans = new char[n];
        var ansIdx = 0;
        foreach(var (ch, frq) in sortedList){
            for(var i=0; i<frq; i++){
                ans[ansIdx] = ch;
                
                ansIdx += 2;
                if(ansIdx >= n) ansIdx = 1;
            }
        }
        
        return new String(ans);
    }
}