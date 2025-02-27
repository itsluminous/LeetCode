public class Solution {
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        // how much max can we get by rearranging first k meetings
        var free = 0;
        for(var i=0; i<k; i++)
            free += GetEmptyOnLeft(startTime, endTime, i);
        
        var maxFree = free + GetEmptyOnRight(startTime, endTime, eventTime, k-1);

        // now slide that k window one by one
        for(int l=0, r=k; r < startTime.Length; l++, r++){
            free -= GetEmptyOnLeft(startTime, endTime, l);
            free += GetEmptyOnLeft(startTime, endTime, r);
            maxFree = Math.Max(maxFree, free + GetEmptyOnRight(startTime, endTime, eventTime, r));
        }

        return maxFree;
    }

    private int GetEmptyOnLeft(int[] startTime, int[] endTime, int idx){
        if(idx == 0)
            return startTime[idx] - 0;
        return startTime[idx] - endTime[idx-1];
    }

    private int GetEmptyOnRight(int[] startTime, int[] endTime, int eventTime, int idx){
        if(idx == startTime.Length-1)
            return eventTime - endTime[idx];
        return startTime[idx+1] - endTime[idx];
    }
}