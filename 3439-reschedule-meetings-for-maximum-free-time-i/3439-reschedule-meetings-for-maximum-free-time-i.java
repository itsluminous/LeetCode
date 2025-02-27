class Solution {
    public int maxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        // how much max can we get by rearranging first k meetings
        var free = 0;
        for(var i=0; i<k; i++)
            free += getEmptyOnLeft(startTime, endTime, i);
        
        var maxFree = free + getEmptyOnRight(startTime, endTime, eventTime, k-1);

        // now slide that k window one by one
        for(int l=0, r=k; r < startTime.length; l++, r++){
            free -= getEmptyOnLeft(startTime, endTime, l);
            free += getEmptyOnLeft(startTime, endTime, r);
            maxFree = Math.max(maxFree, free + getEmptyOnRight(startTime, endTime, eventTime, r));
        }

        return maxFree;
    }

    private int getEmptyOnLeft(int[] startTime, int[] endTime, int idx){
        if(idx == 0)
            return startTime[idx] - 0;
        return startTime[idx] - endTime[idx-1];
    }

    private int getEmptyOnRight(int[] startTime, int[] endTime, int eventTime, int idx){
        if(idx == startTime.length-1)
            return eventTime - endTime[idx];
        return startTime[idx+1] - endTime[idx];
    }
}