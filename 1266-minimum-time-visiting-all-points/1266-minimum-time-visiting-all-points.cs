public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {
        var time = 0;
        int x0 = points[0][0], y0 = points[0][1];

        foreach(var point in points){
            int x1 = point[0], y1 = point[1];
            time += Math.Max(Math.Abs(x1 - x0), Math.Abs(y1 - y0));
            x0 = x1; y0 = y1;
        }

        return time;
    }
}