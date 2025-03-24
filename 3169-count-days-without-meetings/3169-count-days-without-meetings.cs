public class Solution {
    public int CountDays(int days, int[][] meetings) {
        Array.Sort(meetings, (m1, m2) => m1[0] - m2[0]);
        int freeDays = 0, prevEnd = 0;

        // merge intervals, and track free days when new interval is started
        foreach(var meeting in meetings){
            int currStart = meeting[0], currEnd = meeting[1];
            if(currStart > prevEnd)
                freeDays += currStart - prevEnd - 1;
            prevEnd = Math.Max(prevEnd, currEnd);
        }

        // include days we are free after last meeting
        freeDays += days - prevEnd;
        return freeDays;
    }
}