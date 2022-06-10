public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;
        
        var set = new HashSet<char>();
        int maxlen = 0, l=0, r=0;
        while(r < s.Length){
            // if char at r index is new
            if(set.Add(s[r])){
                r++;
                continue;
            }
            // if it is repeated, then keep removing chars from left of string
            maxlen = Math.Max(maxlen, r-l);
            do{
                set.Remove(s[l]);
                l++;
            }while(!set.Add(s[r]));
            r++;
        }
        
        maxlen = Math.Max(maxlen, r-l);
        return maxlen;
    }
}