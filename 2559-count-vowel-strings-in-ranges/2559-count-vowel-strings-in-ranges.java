class Solution {
    public int[] vowelStrings(String[] words, int[][] queries) {
        char[] vowels = {'a', 'e', 'i', 'o', 'u'};
        int w = words.length, q = queries.length;

        // create prefix array
        var pre = new int[w+1];
        for(var i=1; i<=w; i++){
            var word = words[i-1];
            char first = word.charAt(0), last = word.charAt(word.length() - 1);
            if (isVowel(first, vowels) && isVowel(last, vowels))
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

    private boolean isVowel(char c, char[] vowels) {
        for (var vowel : vowels)
            if (c == vowel) return true;
        return false;
    }
}