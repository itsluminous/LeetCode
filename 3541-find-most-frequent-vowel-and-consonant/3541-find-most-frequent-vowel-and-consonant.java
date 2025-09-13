class Solution {
    public int maxFreqSum(String s) {
        var vowels = new HashSet<Character>(Arrays.asList('a', 'e', 'i', 'o', 'u'));
        var freq = new int[26];
        int v = 0, c = 0;

        for(var ch : s.toCharArray()){
            freq[ch-'a']++;
            if(vowels.contains(ch)) v = Math.max(v, freq[ch-'a']);
            else c = Math.max(c, freq[ch-'a']);
        }

        return v + c;
    }
}