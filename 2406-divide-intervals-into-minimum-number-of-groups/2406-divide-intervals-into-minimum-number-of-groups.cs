public class Solution {
    public int MinGroups(int[][] intervals) {
        // sort by start time
        Array.Sort(intervals, (i1, i2) => i1[0] - i2[0]);

        // minHeap to track endingTime for each interval group
        var endTime = new PriorityQueue<int, int>();

        foreach(var interval in intervals){
            // if the end time of smallest range is smaller than current interval
            // then we can add current interval to same group, i.e. replace end time of that with current
            // else we need to create a new group
            if(endTime.Count > 0 && endTime.Peek() < interval[0])
                endTime.Dequeue();
            endTime.Enqueue(interval[1], interval[1]);
        }

        return endTime.Count;
    }
}