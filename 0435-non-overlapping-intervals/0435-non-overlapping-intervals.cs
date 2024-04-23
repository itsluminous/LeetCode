// idea is to find out which intervals can be kept, then remove others
public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        // sort by end
        Array.Sort(intervals, (i1, i2) => i1[1].CompareTo(i2[1]));

        // greedily keep all the intervals that are distinct
        var keep = 1;
        var (prevl, prevr) = (intervals[0][0], intervals[0][1]);
        for(var i=1; i<intervals.Length; i++){
            var (curl, curr) = (intervals[i][0], intervals[i][1]);
            if(curl >= prevr){
                (prevl, prevr) = (curl, curr);
                keep++;
            }
        }

        return intervals.Length - keep;
    }
}