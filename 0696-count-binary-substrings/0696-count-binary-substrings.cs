public class Solution {
    public int CountBinarySubstrings(string s) {
        var ans = 0;
        int z = 0, o = 0;
        var prev = s[0];

        foreach(var curr in s){
            if(curr == prev){
                if(curr == '0') z++;
                else o++;
            }
            else {
                ans += Math.Min(z, o);
                if(curr == '0') z = 1;
                else o = 1;
                prev = curr;
            }
        }

        ans += Math.Min(z, o);
        return ans;
    }
}