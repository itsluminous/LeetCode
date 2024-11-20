public class Solution {
    public int TakeCharacters(string s, int k) {
        if(k == 0) return 0;    // special case

        var freq = new int[3];
        foreach(var ch in s)
            freq[ch - 'a']++;
        if(freq[0] < k || freq[1] < k || freq[2] < k) return -1;    // not possible

        freq = new int[3];  // reset the counter
        
        int n = s.Length, r=n-1;
        // count how many chars we need if we take only right side
        while(r >= 0){
            freq[s[r] - 'a']++;
            if(freq[0] >= k && freq[1] >= k && freq[2] >= k) break;
            r--;
        }
        var ans = n-r;

        // increment l one by one, and try to remove chars from right
        for(var l=0; l < n && l <= r; l++){
            freq[s[l] - 'a']++;
            while(r < n && freq[s[r] - 'a'] > k) {
                freq[s[r] - 'a']--;
                r++;
            }
            ans = Math.Min(ans, 1 + l + n - r);
        }

        return ans;
    }
}