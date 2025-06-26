class Solution {
    public int longestSubsequence(String s, int k) {
        var ss = s.toCharArray();

        // pick all digits from right till it does not exceed k
        long num = 0, pow = 1;
        int idx = ss.length - 1, cnt = 0;
        for(; idx >= 0 && num + pow <= k; idx--){
            if(ss[idx] == '1')
                num += pow;
            pow <<= 1;
            cnt++;
        }

        // prefix all 0's
        while(idx >= 0)
            if(ss[idx--] == '0')
                cnt++;

        return cnt;
    }
}