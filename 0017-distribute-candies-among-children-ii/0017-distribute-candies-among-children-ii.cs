public class Solution {
    public long DistributeCandies(int n, int limit) {
        long ans = 0;
        var child1Min = Math.Max(0, n - 2 * limit); // to ensure child2 & child3 are in limit
        var child1Max = Math.Min(limit, n);         // cannot exceed limit

        for(var child1 = child1Min; child1 <= child1Max; child1++){
            var remaining = n - child1;
            var child2Min = Math.Max(0, remaining - limit); // so that child3 is in limit
            var child2Max = Math.Min(remaining, limit);     // ensure child2 is in limit
            ans += child2Max - child2Min + 1;               // +1 because max & min range is inclusive
        }
        return ans;
    }
}