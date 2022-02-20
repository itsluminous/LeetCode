public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        var sortedIntervals = intervals.OrderBy(i => i[0]).ThenByDescending(i => i[1]).ToArray();
        int start = sortedIntervals[0][0], end = sortedIntervals[0][1], count = 1;
        
        foreach(var interval in sortedIntervals){
            // continue loop if this interval is covered
            if(interval[0] >= start && interval[1] <= end) continue;

            start = interval[0];
            end = interval[1];
            count++;
        }
        
        return count;
    }
}