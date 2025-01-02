public class Solution {
    public int[] VowelStrings(string[] words, int[][] queries) {
        var vowels = new char[]{'a', 'e', 'i', 'o', 'u'};
        int w = words.Length, q = queries.Length;

        // create prefix array
        var pre = new int[w+1];
        for(var i=1; i<=w; i++){
            var word = words[i-1];
            char first = word[0], last = word[word.Length - 1];
            if(vowels.Contains(first) && vowels.Contains(last))
                pre[i] = pre[i-1] + 1;
            else
                pre[i] = pre[i-1];
        }

        // update ans based on prefix array
        var ans = new int[q];
        for(var i=0; i<q; i++){
            int start = queries[i][0], end = 1 + queries[i][1];
            ans[i] = pre[end] - pre[start];
        }

        return ans;
    }
}