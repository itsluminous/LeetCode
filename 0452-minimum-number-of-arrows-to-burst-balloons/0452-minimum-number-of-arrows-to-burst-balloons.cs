public class Solution {
    public int FindMinArrowShots(int[][] points) {
        var n = points.Length;
        Array.Sort(points, (x, y) => x[0].CompareTo(y[0])); // sort based on start idx

        var arrows = 1;
        var (prevStart, prevEnd) = (points[0][0], points[0][1]);

        for(var i=1; i<n; i++){
            var (currStart, currEnd) = (points[i][0], points[i][1]);
            if(currStart <= prevEnd)
                prevEnd = Math.Min(prevEnd, currEnd);   // no need to shoot new arrow
            else{      // shoot new arrow                                 
                prevEnd = currEnd;
                arrows++;
            }
            prevStart = currStart;
        }

        return arrows;
    }
}

// Accepted - Sort based on End point
public class SolutionEndPoint {
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