public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        var n = A.Length;
        var count = new int[n+1];
        var ans = new int[n];

        var common = 0;
        for(var i=0; i<n; i++){
            count[A[i]]++;
            if(count[A[i]] == 2) common++;

            count[B[i]]++;
            if(count[B[i]] == 2) common++;

            ans[i] = common;
        }

        return ans;
    }
}