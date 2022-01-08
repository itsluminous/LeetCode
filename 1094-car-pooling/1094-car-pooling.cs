public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        var journey = new int[1001];    // because 0 <= from < to <= 1000
        var maxEnd = 0;                 // we keep this to shorten the second loop
        
        // loop 1 : mark all points where passengers board or get down
        foreach(var trip in trips){
            journey[trip[1]] += trip[0];
            journey[trip[2]] -= trip[0];
            maxEnd = Math.Max(maxEnd, trip[2]);
        }
        
        // loop 2 : do a total to find if at any point we crossed capacity
        var curr = 0;
        for(var i=0; i<=maxEnd; i++){
            curr += journey[i];
            if(curr > capacity) return false;
        }
        
        return true;
    }
}