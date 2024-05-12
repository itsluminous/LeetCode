class Solution {
    public int findPermutationDifference(String s, String t) {
        var pos = new int[26];
        for(var i=0; i<s.length(); i++)
            pos[s.charAt(i)-'a'] = i;
        
        var ans = 0;
        for(var i=0; i<t.length(); i++)
            ans += Math.abs(pos[t.charAt(i)-'a'] - i);
        
        return ans;
    }
}