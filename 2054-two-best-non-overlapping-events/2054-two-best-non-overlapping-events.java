class Solution {
    public int maxTwoEvents(int[][] events) {
        // array to track which event started or ended at any given point
        var times = new ArrayList<int[]>();
        for(var event : events){
            int start = event[0], end = event[1], value = event[2];
            times.add(new int[]{start, 1, value});  // time, is_start, value
            times.add(new int[]{end+1, 0, value});  // end+1 because events array is inclusive
        }
        
        times.sort((a,b) -> a[0] == b[0] ? a[1] - b[1] : a[0] - b[0]);    // sort by start time, then end time

        int ans = 0, maxTillNow = 0;
        for(var time : times){
            if(time[1] == 1)
                // if we found a start array, then check if this + prev max is max ans
                ans = Math.max(ans, maxTillNow + time[2]);
            else
                // for end time, we just update maxTillNow with curr value if this is bigger
                maxTillNow = Math.max(maxTillNow, time[2]);
        }
        
        return ans;
    }
}