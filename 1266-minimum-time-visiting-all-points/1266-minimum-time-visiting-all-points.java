class Solution {
    public int minTimeToVisitAllPoints(int[][] points) {
        var time = 0;
        int x0 = points[0][0], y0 = points[0][1];

        for(var point : points){
            int x1 = point[0], y1 = point[1];
            time += Math.max(Math.abs(x1 - x0), Math.abs(y1 - y0));
            x0 = x1; y0 = y1;
        }

        return time;
    }
}