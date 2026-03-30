public class Solution {
    public bool CanBeEqual(string s1, string s2) {
        var n = 4;  // from constraints, length will always be 4
        int[] oddFreq = new int[26], evenFreq = new int[26];
        for(var i=0; i<n; i+=2) evenFreq[s1[i] - 'a'] += 1;
        for(var i=1; i<n; i+=2) oddFreq[s1[i] - 'a'] += 1;

        for(var i=0; i<n; i+=2){
            evenFreq[s2[i] - 'a'] -= 1;
            if(evenFreq[s2[i] - 'a'] < 0) return false;
        }
        for(var i=1; i<n; i+=2){
            oddFreq[s2[i] - 'a'] -= 1;
            if(oddFreq[s2[i] - 'a'] < 0) return false;
        }
        return true;
    }
}