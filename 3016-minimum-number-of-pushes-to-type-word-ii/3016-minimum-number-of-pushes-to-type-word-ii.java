class Solution {
    public int minimumPushes(String word) {
        var freq = new int[26];
        for(var ch : word.toCharArray())
            freq[ch - 'a']++;
        
        Arrays.sort(freq);
        var count = 0;

        for(int i=25, press=1; i>=0 && freq[i] != 0; i-=8, press++)
            for(var j=i; j>=0 && j>(i-8); j--)
                count += freq[j] * press;

        return count;
    }
}