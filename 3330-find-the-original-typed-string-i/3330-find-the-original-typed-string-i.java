class Solution {
    public int possibleStringCount(String word) {
        var ans = 1;    // 1 = full string
        for(var i=1; i<word.length(); i++)
            if(word.charAt(i) == word.charAt(i-1))
                ans++;
        return ans;
    }
}