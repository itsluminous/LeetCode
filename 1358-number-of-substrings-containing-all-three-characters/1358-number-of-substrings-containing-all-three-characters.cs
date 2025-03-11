public class Solution {
    public int NumberOfSubstrings(string s) {
        int n = s.Length, count = 0;
        var freq = new int[3];

        for(int l = 0, r = 0; r < n; r++){
            freq[s[r] - 'a']++;
            // every time we find all a,b,c - we can expand it to end of string potentially
            while(freq[0] > 0 && freq[1] > 0 && freq[2] > 0){
                count += n - r;
                freq[s[l] - 'a']--;
                l++;
            }
        }

        return count;
    }
}