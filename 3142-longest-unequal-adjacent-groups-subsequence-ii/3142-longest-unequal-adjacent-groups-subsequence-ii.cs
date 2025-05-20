public class Solution {
    public IList<string> GetWordsInLongestSubsequence(string[] words, int[] groups) {
        int n = words.Length, maxLenIdx = 0;
        var maxLen = new int[n];    // Length of longest subsequence till index i
        var prevIdx = new int[n];   // index of the last word which led to maxLen

        for(var i=0; i<n; i++){
            maxLen[i] = 1;
            prevIdx[i] = -1;
            for(var j=i-1; j>=0; j--){
                if( maxLen[j] < maxLen[i] ||
                    groups[i] == groups[j] ||
                    words[i].Length != words[j].Length ||
                    !HamDistOne(words[i], words[j])
                ) continue;
                prevIdx[i] = j;
                maxLen[i] = maxLen[j] + 1;
                if(maxLen[maxLenIdx] < maxLen[i]) maxLenIdx = i;
            }
        }

        var ans = new List<string>();
        while(maxLenIdx >= 0){
            ans.Add(words[maxLenIdx]);
            maxLenIdx = prevIdx[maxLenIdx];
        }

        ans.Reverse();
        return ans;
    }

    private bool HamDistOne(String word1, String word2){
        var dist = 0;
        for(var i=0; i<word1.Length; i++){
            if(word1[i] == word2[i]) continue;
            if(dist == 1) return false;
            dist++;
        }
        return dist == 1;
    }
}