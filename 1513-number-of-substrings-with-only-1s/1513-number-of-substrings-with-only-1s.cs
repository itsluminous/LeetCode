public class Solution {
    public int NumSub(string s) {
        var MOD = 1_000_000_007;
        long ans = 0, ones = 0;

        foreach(var ch in s){
            if(ch == '1')
                ones++;
            else if (ones != 0) {
                ans += (ones + 1) * ones / 2;
                ans %= MOD;
                ones = 0;
            }
        }

        if(ones != 0){
            ans += (ones + 1) * ones / 2;
            ans %= MOD;
        }

        return (int)ans;
    }
}