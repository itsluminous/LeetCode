class Solution {
    public String longestSubsequenceRepeatedK(String s, int k) {
        var freq = new int[26];
        for(var ch : s.toCharArray())
            freq[ch-'a']++;
        
        // find all chars which repeat >= k 
        // in desc order (to get lexicographically largest answer)
        var chars = new ArrayList<Character>();
        for(var i=25; i>=0; i--)
            if(freq[i] >= k)
                chars.add((char)('a' + i));
        
        // Create a queue to try all subsequences
        // Starting with single letter subsequence
        Queue<String> queue = new LinkedList<>();
        for(var ch : chars)
            queue.offer(String.valueOf(ch));
        
        var ans = "";
        while(!queue.isEmpty()){
            var curr = queue.poll();
            if(curr.length() > ans.length()) ans = curr;
            // generate next candidate by enumerating over all chars >= k
            for(var ch : chars){
                var next = curr + ch;
                if(isKRepeatedSubsequence(s, next, k))
                    queue.offer(next);
            }
        }

        return ans;
    }

    private boolean isKRepeatedSubsequence(String s, String t, int k) {
        int tLen = t.length(), tIdx = 0, matchCount = 0;
        for(var ch : s.toCharArray()){
            if(ch == t.charAt(tIdx)){
                tIdx++;
                // found full match of substring
                if(tIdx == tLen){
                    tIdx = 0;   // check for next occurence
                    matchCount++;
                    if(matchCount == k) // found k occurence of substring
                        return true;
                }
            }
        }
        return false;
    }
}