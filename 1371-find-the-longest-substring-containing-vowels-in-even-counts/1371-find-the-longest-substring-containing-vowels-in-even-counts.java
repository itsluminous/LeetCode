class Solution {
    public int findTheLongestSubstring(String s) {
        int maxLen = 0, mask = 0;
        var seenIdx = new HashMap<Integer, Integer>();   // index of when a bitmask was seen
        seenIdx.put(0, -1);    // 0 chars of string
        
        for(var i=0; i<s.length(); i++){
            mask = getNewMask(s.charAt(i), mask);
            if(seenIdx.containsKey(mask))
                maxLen = Math.max(maxLen, i - seenIdx.get(mask));
            else
                seenIdx.put(mask, i);
        }
        return maxLen;
    }

    private int getNewMask(char ch, int mask){
        if(ch == 'a') return mask ^ 1;         // 00001
        else if(ch == 'e') return mask ^ 2;    // 00010
        else if(ch == 'i') return mask ^ 4;    // 00100
        else if(ch == 'o') return mask ^ 8;    // 01000
        else if(ch == 'u') return mask ^ 16;   // 10000
        else return mask;
    }
}