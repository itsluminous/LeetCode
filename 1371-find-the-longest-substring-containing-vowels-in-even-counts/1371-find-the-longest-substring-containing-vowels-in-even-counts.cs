public class Solution {
    public int FindTheLongestSubstring(string s) {
        int maxLen = 0, mask = 0;
        var seenIdx = new Dictionary<int, int>();   // index of when a bitmask was seen
        seenIdx[0] = -1;    // 0 chars of string
        
        for(var i=0; i<s.Length; i++){
            mask = GetNewMask(s[i], mask);
            if(seenIdx.ContainsKey(mask))
                maxLen = Math.Max(maxLen, i - seenIdx[mask]);
            else
                seenIdx[mask] = i;
        }
        return maxLen;
    }

    private int GetNewMask(char ch, int mask){
        return ch switch
        {
            'a' => mask ^ 1,    // 00001
            'e' => mask ^ 2,    // 00010
            'i' => mask ^ 4,    // 00100
            'o' => mask ^ 8,    // 01000
            'u' => mask ^ 16,   // 10000
            _ => mask
        };
    }
}