class Solution {
    int[][] dp;             // for given [moves][num], how many possibilities
    int[][] keypadMap;      // neighbours for each number
    int MOD = 1_000_000_007;

    public int knightDialer(int n) {
        initialize(n);
        var count = 0;
        for(var digit=0; digit<10; digit++)
            count = (count + move(digit, n-1)) % MOD;
        return count;
    }

    private int move(int digit, int moves){
        if(moves == 0) return 1;
        if(dp[moves][digit] > 0) return dp[moves][digit];

        var count = 0;
        var neighbours = keypadMap[digit];
        for(var next : neighbours)
            count = (count + move(next, moves-1)) % MOD;
        
        dp[moves][digit] = count;
        return count;
    }

    private void initialize(int n){
        dp = new int[n][10];
        keypadMap = new int[][]{
            {4, 6},     {6, 8},     {7, 9},     {4, 8},     {0, 3, 9},
            {},         {0, 1, 7},  {2, 6},     {1, 3},     {2, 4}
        };
    }
}