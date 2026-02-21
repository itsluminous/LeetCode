class Solution {
    public int countBinarySubstrings(String s) {
        var ans = 0;
        int z = 0, o = 0;
        var prev = s.charAt(0);

        for(var curr : s.toCharArray()){
            if(curr == prev){
                if(curr == '0') z++;
                else o++;
            }
            else {
                ans += Math.min(z, o);
                if(curr == '0') z = 1;
                else o = 1;
                prev = curr;
            }
        }

        ans += Math.min(z, o);
        return ans;
    }
}