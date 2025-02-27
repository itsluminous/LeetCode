class Solution {
    public int maxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        var n = startTime.length;
        
        // gap between all intervals
        var gap = new int[n+1];
        gap[0] = startTime[0];
        gap[n] = eventTime - endTime[n-1];
        for(var i=1; i<n; i++)
            gap[i] = startTime[i] - endTime[i-1];

        // biggest gap on right of any idx
        var largestRight = new int[n+1];
        for(var i=n-1; i>=0; i--)
            largestRight[i] = Math.max(largestRight[i+1], gap[i+1]);
        
        // we also need to track biggest gap on left of any idx
        // but we can track that while forming ans, no need to do separately

        // now, for each interval, we have two options
        // 1. if there is any gap either on left or right where this interval can fit, throw it there
        // 2. just slide it left or right without jumping. like in Problem 3439
        int ans = 0, largestLeft = 0;
        for(var i=0; i<n; i++){
            var duration = endTime[i] - startTime[i];
            // 1. try to place current interval somewhere on left or right
            if(largestLeft >= duration || largestRight[i+1] >= duration)
                ans = Math.max(ans, gap[i] + gap[i+1] + duration);
            
            // 2. just slide interval on left or right (no jumping)
            ans = Math.max(ans, gap[i] + gap[i+1]);
            largestLeft = Math.max(largestLeft, gap[i]);
        }
        
        return ans;
    }
}