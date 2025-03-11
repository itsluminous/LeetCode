class Solution {
    public int numberOfSubstrings(String s) {
        int n = s.length(), count = 0;
        var freq = new int[3];

        for(int l = 0, r = 0; r < n; r++){
            freq[s.charAt(r) - 'a']++;
            // every time we find all a,b,c - we can expand it to end of string potentially
            while(freq[0] > 0 && freq[1] > 0 && freq[2] > 0){
                count += n - r;
                freq[s.charAt(l) - 'a']--;
                l++;
            }
        }

        return count;
    }
}