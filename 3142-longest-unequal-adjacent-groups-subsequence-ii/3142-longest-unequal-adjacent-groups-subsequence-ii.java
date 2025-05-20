class Solution {
    public List<String> getWordsInLongestSubsequence(String[] words, int[] groups) {
        int n = words.length, maxLenIdx = 0;
        var maxLen = new int[n];    // length of longest subsequence till index i
        var prevIdx = new int[n];   // index of the last word which led to maxLen

        for(var i=0; i<n; i++){
            maxLen[i] = 1;
            prevIdx[i] = -1;
            for(var j=i-1; j>=0; j--){
                if( maxLen[j] < maxLen[i] ||
                    groups[i] == groups[j] ||
                    words[i].length() != words[j].length() ||
                    !hamDistOne(words[i], words[j])
                ) continue;
                prevIdx[i] = j;
                maxLen[i] = maxLen[j] + 1;
                if(maxLen[maxLenIdx] < maxLen[i]) maxLenIdx = i;
            }
        }

        var ans = new ArrayList<String>();
        while(maxLenIdx >= 0){
            ans.add(words[maxLenIdx]);
            maxLenIdx = prevIdx[maxLenIdx];
        }

        Collections.reverse(ans);
        return ans;
    }

    private boolean hamDistOne(String word1, String word2){
        var dist = 0;
        for(var i=0; i<word1.length(); i++){
            if(word1.charAt(i) == word2.charAt(i)) continue;
            if(dist == 1) return false;
            dist++;
        }
        return dist == 1;
    }
}