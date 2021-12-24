public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (i1,i2) => i1[0].CompareTo(i2[0]));
        var result = new List<int[]>();
        int start=intervals[0][0], end = intervals[0][1];
        foreach(var interval in intervals){
            // if current start is greater than prev end
            if(interval[0] > end){
                result.Add(new []{start, end});
                start = interval[0];
                end = interval[1];
            }
            // else update the end interval
            else if(interval[1] > end){
                end = interval[1];
            }
        }
        result.Add(new []{start, end});
        
        return result.ToArray();
    }
}