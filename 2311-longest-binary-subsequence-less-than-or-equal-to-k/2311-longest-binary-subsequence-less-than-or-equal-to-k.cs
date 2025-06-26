public class Solution {
    public int LongestSubsequence(string s, int k) {
        // pick all digits from right till it does not exceed k
        long num = 0, pow = 1;
        int idx = s.Length - 1, cnt = 0;
        for(; idx >= 0 && num + pow <= k; idx--){
            if(s[idx] == '1')
                num += pow;
            pow <<= 1;
            cnt++;
        }

        // prefix all 0's
        while(idx >= 0)
            if(s[idx--] == '0')
                cnt++;

        return cnt;
    }
}