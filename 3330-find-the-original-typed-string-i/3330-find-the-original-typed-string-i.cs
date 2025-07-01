public class Solution {
    public int PossibleStringCount(string word) {
        var ans = 1;    // 1 = full string
        for(var i=1; i<word.Length; i++)
            if(word[i] == word[i-1])
                ans++;
        return ans;
    }
}