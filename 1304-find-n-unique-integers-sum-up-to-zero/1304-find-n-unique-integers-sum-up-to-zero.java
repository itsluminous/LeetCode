class Solution {
    public int[] sumZero(int n) {
        var ans = new int[n];
        int idx = 0, num = 1;
        
        // for odd length, we need extra digit
        if((n & 1) == 1)
            ans[idx++] = 0;
        
        while(idx < n){
            ans[idx++] = -num;
            ans[idx++] = num++;
        }

        return ans;
    }
}