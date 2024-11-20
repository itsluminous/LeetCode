class Solution {
    public int takeCharacters(String s, int k) {
        if(k == 0) return 0;    // special case

        int[] freq = new int[3];
        for(var ch : s.toCharArray())
            freq[ch - 'a']++;
        if(freq[0] < k || freq[1] < k || freq[2] < k) return -1;    // not possible

        freq = new int[3];  // reset the counter
        
        int n = s.length(), r=n-1;
        // count how many chars we need if we take only right side
        while(r >= 0){
            freq[s.charAt(r) - 'a']++;
            if(freq[0] >= k && freq[1] >= k && freq[2] >= k) break;
            r--;
        }
        var ans = n-r;

        // increment l one by one, and try to remove chars from right
        for(var l=0; l < n && l <= r; l++){
            freq[s.charAt(l) - 'a']++;
            while(r < n && freq[s.charAt(r) - 'a'] > k) {
                freq[s.charAt(r) - 'a']--;
                r++;
            }
            ans = Math.min(ans, 1 + l + n - r);
        }

        return ans;
    }
}