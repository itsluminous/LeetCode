class Solution {
    public int minimumDeletions(String word, int k) {
        var freq = new int[26];
        for(var ch : word.toCharArray()) freq[ch-'a']++;
        var uniqFreq = Arrays.stream(freq).boxed().collect(Collectors.toSet());

        var minRemove = Integer.MAX_VALUE;
        // we assume each freq as smallest in answer, and then check which numbers need to be removed to make it true
        for(var minFreq : uniqFreq){
            if(minFreq == 0) continue;
            var currRemove = 0;

            for(var f : freq){
                if(f < minFreq) currRemove += f;
                else if(f > minFreq + k) currRemove += f - minFreq - k; // remove occurences outside minFreq+k range
            }
            minRemove = Math.min(minRemove, currRemove);
        }
        
        return minRemove;
    }
}