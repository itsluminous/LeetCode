class Solution {
    public int maxDifference(String s) {
        var freq = new int[26];
        for(var ch : s.toCharArray())
            freq[ch-'a']++;

        int oddFreq = 0, evenFreq = 101;
        for(var f : freq){
            if(f == 0) continue;
            if((f & 1) == 1) oddFreq = Math.max(oddFreq, f);
            else evenFreq = Math.min(evenFreq, f);
        }

        return oddFreq - evenFreq;
    }
}