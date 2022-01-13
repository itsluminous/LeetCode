public class Solution {
    public int FindMinArrowShots(int[][] points) {
        // sort the array based on ending point
        Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));
        // initialize variables based on first balloon
        var shooting_point = points[0][1];
        var arrows = 1;
        // now check how many arrows will be needed
        for(var i=1; i<points.Length; i++){
            // if this balloon has starting point before shooting_point, then it would already be shot
            if(points[i][0] <= shooting_point) continue;
            // else we need to fire another arrow
            shooting_point = points[i][1];
            arrows++;
        }
        return arrows;
    }
}