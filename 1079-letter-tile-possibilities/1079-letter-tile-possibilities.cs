public class Solution {
    public int NumTilePossibilities(string tiles) {
        var freq = new int[26];
        foreach(var ch in tiles)
            freq[ch - 'A']++;
        
        return CountSequences(freq);
    }

    private int CountSequences(int[] freq){
        var count = 0;
        for(var i=0; i<26; i++){
            if(freq[i] == 0) continue;
            count++;

            // backtrack
            freq[i]--;
            count += CountSequences(freq);
            freq[i]++;
        }

        return count;
    }

}