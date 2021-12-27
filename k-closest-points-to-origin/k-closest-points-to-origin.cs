public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        return points.OrderBy(p => p[0] * p[0] + p[1] * p[1]).Take(k).ToArray();
    }
}