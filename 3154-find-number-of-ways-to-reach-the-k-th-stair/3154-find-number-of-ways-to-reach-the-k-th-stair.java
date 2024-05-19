// backtracking with memoization
class Solution {
    HashMap<String, Integer> dp;

    public int waysToReachStair(int k) {
        if(k <= 1) return (int)Math.pow(2, k+1);

        dp = new HashMap<>();
        return solve(k, 1, 0, true);
    }

    private int solve(int k, int i, int jump, boolean canGoDown)
    {
        // Base cases
        if (i > k + 5 || jump > 31) return 0;   // 31 because 2^31 is limit of k

        // Check memoization
        var key = i + "," + jump + "," + canGoDown;
        if (dp.containsKey(key))
            return dp.get(key);

        var ans = (i == k) ? 1 : 0;     // If current step is the target

        // if we did not go down in prev step, then go down now
        if (canGoDown)
            ans += solve(k, i - 1, jump, false);

        // if 2^jump is <= k, then we have a way to reach the kth step
        if ((1 << jump) <= k)
            ans += solve(k, i + (1 << jump), jump + 1, true);

        // Memoization
        dp.put(key, ans);
        return ans;
    }
}