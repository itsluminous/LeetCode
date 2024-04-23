// idea is to always shoot at the end of first point in a batch
public class Solution {
    public int FindMinArrowShots(int[][] points) {
        Array.Sort(points, (p1, p2) => p1[0].CompareTo(p2[0]));     // sort by start point
        var shots = 1;
        
        var (prevl, prevr) = (points[0][0], points[0][1]);
        for(var i=1; i<points.Length; i++){
            var (curl, curr) = (points[i][0], points[i][1]);

            // if this point is not fitting in range of previous shot, then fire new shot
            if(curl > prevr){
                (prevl, prevr) = (curl, curr);
                shots++;
            }
            else prevr = Math.Min(prevr, curr);     // can only go as right as the leftest balloon in the batch
        }

        return shots;
    }
}