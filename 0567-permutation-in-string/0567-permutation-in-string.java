class Solution {
    public boolean checkInclusion(String s1, String s2) {
        var freq = new int[26];
        for(var ch : s1.toCharArray())
            freq[ch - 'a']++;
        
        var curr = freq.clone();
        int l=0, r=0, count=0;
        while(r < s2.length()){
            var rpos = s2.charAt(r) - 'a';
            // if this char does not exist in s1
            if(freq[rpos] == 0){
                l = r = r+1;
                count = 0;
                curr = freq.clone();
            }
            else {
                // if this char is breaking permutation
                while(curr[rpos] == 0){
                    var lpos = s2.charAt(l) - 'a';
                    curr[lpos]++;
                    count--;
                    l++;
                }

                // include curr char in permutation
                curr[rpos]--;
                count++;
                r++;
            }

            // did we find permutation?
            if(count == s1.length()) return true;
        }
        return false;
    }
}