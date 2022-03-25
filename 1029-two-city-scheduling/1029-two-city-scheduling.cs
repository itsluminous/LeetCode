// Explaination : https://leetcode.com/problems/two-city-scheduling/discuss/667786/Java-or-C%2B%2B-or-Python3-or-With-detailed-explanation
public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        var n = costs.Length / 2;
        var costOfA = costs.Select(c => c[0]).Sum();
        var refundOfB = costs.Select(c => c[1] - c[0]).OrderBy(c=>c).Take(n).Sum();
        return costOfA + refundOfB;
    }
}