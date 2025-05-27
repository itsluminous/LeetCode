public class Solution {
    public int DifferenceOfSums(int n, int m) {
        var ans = 0;
        for(var i=1; i<=n; i++){
            if(i % m == 0) ans -= i;
            else ans += i;
        }
        return ans;
    }
}