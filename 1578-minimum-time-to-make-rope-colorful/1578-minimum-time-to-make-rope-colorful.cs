public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        int n = colors.Length, sum = 0;
        for (int i = 1; i < n; i++) {
            if (colors[i] == colors[i-1]) {
                sum += Math.Min(neededTime[i], neededTime[i - 1]);
                neededTime[i] = Math.Max(neededTime[i], neededTime[i - 1]);
            }
        }
        return sum;
    }
}