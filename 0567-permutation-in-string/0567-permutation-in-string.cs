public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var freq = new int[26];
        foreach(var ch in s1)
            freq[ch - 'a']++;
        
        var curr = (int[])freq.Clone();
        int l=0, r=0, count=0;
        while(r < s2.Length){
            var rpos = s2[r] - 'a';
            // if this char does not exist in s1
            if(freq[rpos] == 0){
                l = r = r+1;
                count = 0;
                curr = (int[])freq.Clone();
            }
            else {
                // if this char is breaking permutation
                while(curr[rpos] == 0){
                    var lpos = s2[l] - 'a';
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
            if(count == s1.Length) return true;
        }
        return false;
    }
}