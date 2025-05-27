class Solution {
    public int differenceOfSums(int n, int m) {
        var c = n / m;                              // count of numbers divisble by m
        var allSum = n * (n+1) / 2;                 // AP sum of first n numbers
        var mSum = (c * (2 * m + (c - 1) * m)) / 2; // AP sum formula = n/2 * (2*a + (n - 1)*d)
        return allSum - 2 * mSum;                   // 2* because we need to subtract extra mSum counted in allSum
    }
}

// Accepted - O(n)
class SolutionN {
    public int differenceOfSums(int n, int m) {
        var ans = 0;
        for(var i=1; i<=n; i++){
            if(i % m == 0) ans -= i;
            else ans += i;
        }
        return ans;
    }
}