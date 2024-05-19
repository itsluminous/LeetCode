// backtracking with memoization
public class Solution {
    Dictionary<(int, int, bool), int> dp;

    public int WaysToReachStair(int k) {
        if(k <= 1) return (int)Math.Pow(2, k+1);

        dp = new Dictionary<(int, int, bool), int>();
        return Solve(k, 1, 0, true);
    }

    private int Solve(int k, int i, int jump, bool canGoDown)
    {
        // Base cases
        if (i > k + 5 || jump > 31) return 0;   // 31 because 2^31 is limit of k

        // Check memoization
        if (dp.ContainsKey((i, jump, canGoDown)))
            return dp[(i, jump, canGoDown)];

        var ans = (i == k) ? 1 : 0;     // If current step is the target

        // if we did not go down in prev step, then go down now
        if (canGoDown)
            ans += Solve(k, i - 1, jump, false);

        // if 2^jump is <= k, then we have a way to reach the kth step
        if ((1 << jump) <= k)
            ans += Solve(k, i + (1 << jump), jump + 1, true);

        // Memoization
        dp[(i, jump, canGoDown)] = ans;
        return ans;
    }
}