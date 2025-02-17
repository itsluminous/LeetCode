class Solution {
    public int numTilePossibilities(String tiles) {
        var freq = new int[26];
        for(var ch : tiles.toCharArray())
            freq[ch - 'A']++;
        
        return countSequences(freq);
    }

    private int countSequences(int[] freq){
        var count = 0;
        for(var i=0; i<26; i++){
            if(freq[i] == 0) continue;
            count++;

            // backtrack
            freq[i]--;
            count += countSequences(freq);
            freq[i]++;
        }

        return count;
    }
}