class Solution {
    public List<String> getLongestSubsequence(String[] words, int[] groups) {
        var ans = new ArrayList<String>();
        ans.add(words[0]);

        for(var i=1; i<words.length; i++)
            if(groups[i] != groups[i-1])
                ans.add(words[i]);

        return ans;
    }
}