class Solution {
    public int[] decrypt(int[] code, int k) {
        var n = code.length;
        var ans = new int[n];
        if(k == 0) return ans;

        int sum = 0, l = 1, r = k;
        if(k < 0){
            k = -k;
            l = n - k;  // l is now actually end of array
            r = n - 1;  // r is start of array
        }
        
        for(var i=l; i<=r; i++) sum += code[i];

        for(var i=0; i<n; i++){
            ans[i] = sum;
            sum -= code[l];
            l = (l + 1) % n;
            r = (r + 1) % n;
            sum += code[r];
        }

        return ans;
    }
}