class Solution {
    public boolean isBoomerang(int[][] points) {
        // check if any two points are same (can be done using hashset also)
        if(points[1][1] == points[0][1] && points[1][0] == points[0][0]) return false;
        if(points[2][1] == points[0][1] && points[2][0] == points[0][0]) return false;
        if(points[2][1] == points[1][1] && points[2][0] == points[1][0]) return false;

        // check if slope is same
        var slope1 = 1.0 * (points[1][1] - points[0][1]) / (points[1][0] - points[0][0]);
        var slope2 = 1.0 * (points[2][1] - points[0][1]) / (points[2][0] - points[0][0]);
        var slope3 = 1.0 * (points[2][1] - points[1][1]) / (points[2][0] - points[1][0]);
        if(Math.abs(slope1) == Math.abs(slope2) && Math.abs(slope2) == Math.abs(slope3)) return false;

        return true;
    }
}