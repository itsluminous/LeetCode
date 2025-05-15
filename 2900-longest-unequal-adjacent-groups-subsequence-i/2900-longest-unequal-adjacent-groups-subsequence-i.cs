public class Solution {
    public IList<string> GetLongestSubsequence(string[] words, int[] groups) {
        var ans = new List<string>{words[0]};

        for(var i = 1; i < words.Length; i++)
            if(groups[i] != groups[i - 1])
                ans.Add(words[i]);

        return ans;
    }
}