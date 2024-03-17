public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        bool added = false;
        var n = intervals.Length;
        var updated = new List<int[]>();

        foreach(var interval in intervals){
            if(interval[0] > newInterval[0] && !added){
                AddToEnd(updated, newInterval);
                added = true;
            }
            AddToEnd(updated, interval);
        }

        if(!added)
            AddToEnd(updated, newInterval);

        return updated.ToArray();
    }

    private void AddToEnd(List<int[]> updated, int[] interval){
        var n = updated.Count;
        if(n == 0){
            updated.Add(interval);
            return;
        }

        var last = updated[n-1];
        if(last[1] >= interval[0])
            last[1] = Math.Max(last[1], interval[1]);
        else
            updated.Add(interval);
    }
}