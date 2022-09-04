public class Solution {
    public bool CheckDistances(string s, int[] distance) {
        var dist = new int[26];
        for(var i=0; i<26; i++) dist[i] = -1;
        
        for(var i=0; i<s.Length; i++){
            var ch = s[i] - 'a';
            if(dist[ch] == -1) dist[ch] = i;  // first occurrence
            else dist[ch] = i - dist[ch] - 1; // second occurrence. calculate distance
        }
        
        for(var i=0; i<26; i++){
            if(dist[i] == -1) continue;
            if(dist[i] != distance[i]) return false;
        }
        
        return true;
    }
}