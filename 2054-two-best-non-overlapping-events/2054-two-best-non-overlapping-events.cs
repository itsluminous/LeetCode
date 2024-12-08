public class Solution {
    public int MaxTwoEvents(int[][] events) {
        // array to track which event started or ended at any given point
        var times = new List<int[]>();
        foreach(var evnt in events){
            int start = evnt[0], end = evnt[1], value = evnt[2];
            times.Add([start, 1, value]);  // time, is_start, value
            times.Add([end+1, 0, value]);  // end+1 because events array is inclusive
        }
        
        times.Sort((a,b) => a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);    // sort by start time, then end time

        int ans = 0, maxTillNow = 0;
        foreach(var time in times){
            if(time[1] == 1)
                // if we found a start array, then check if this + prev max is max ans
                ans = Math.Max(ans, maxTillNow + time[2]);
            else
                // for end time, we just update maxTillNow with curr value if this is bigger
                maxTillNow = Math.Max(maxTillNow, time[2]);
        }
        
        return ans;
    }
}