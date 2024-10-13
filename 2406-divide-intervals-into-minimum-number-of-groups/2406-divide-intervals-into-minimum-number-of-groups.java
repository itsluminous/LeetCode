class Solution {
    public int minGroups(int[][] intervals) {
        // sort by start time
        Arrays.sort(intervals, (i1, i2) -> i1[0] - i2[0]);

        // minHeap to track endingTime for each interval group
        var endTime = new PriorityQueue<Integer>();

        for(var interval : intervals){
            // if the end time of smallest range is smaller than current interval
            // then we can add current interval to same group, i.e. replace end time of that with current
            // else we need to create a new group
            if(!endTime.isEmpty() && endTime.peek() < interval[0])
                endTime.poll();
            endTime.offer(interval[1]);
        }

        return endTime.size();
    }
}