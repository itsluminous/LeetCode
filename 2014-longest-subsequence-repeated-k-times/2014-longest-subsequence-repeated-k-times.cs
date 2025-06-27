public class Solution {
    public string LongestSubsequenceRepeatedK(string s, int k) {
        var freq = new int[26];
        foreach(var ch in s)
            freq[ch-'a']++;
        
        // find all chars which repeat >= k 
        // in desc order (to get lexicographically largest answer)
        var chars = new List<char>();
        for(var i=25; i>=0; i--)
            if(freq[i] >= k)
                chars.Add((char)('a' + i));
        
        // Create a queue to try all subsequences
        // Starting with single letter subsequence
        Queue<string> queue = new();
        foreach(var ch in chars)
            queue.Enqueue(ch.ToString());
        
        var ans = "";
        while(queue.Count > 0){
            var curr = queue.Dequeue();
            if(curr.Length > ans.Length) ans = curr;
            // generate next candidate by enumerating over all chars >= k
            foreach(var ch in chars){
                var next = curr + ch;
                if(IsKRepeatedSubsequence(s, next, k))
                    queue.Enqueue(next);
            }
        }

        return ans;
    }

    private bool IsKRepeatedSubsequence(string s, string t, int k) {
        int tLen = t.Length, tIdx = 0, matchCount = 0;
        foreach(var ch in s){
            if(ch == t[tIdx]){
                tIdx++;
                // found full match of substring
                if(tIdx == tLen){
                    tIdx = 0;   // check for next occurence
                    matchCount++;
                    if(matchCount == k) // found k occurence of substring
                        return true;
                }
            }
        }
        return false;
    }
}