class Solution {
    public int countDays(int days, int[][] meetings) {
        Arrays.sort(meetings, (m1, m2) -> m1[0] - m2[0]);
        
        // initialize freeDays with number of days we are free before first meeting
        var freeDays = meetings[0][0] - 1;
        var prevEnd = meetings[0][1];

        // merge intervals, and track free days when new interval is started
        for(var i=1; i<meetings.length; i++){
            int currStart = meetings[i][0], currEnd = meetings[i][1];
            if(currStart > prevEnd)
                freeDays += currStart - prevEnd - 1;
            prevEnd = Math.max(prevEnd, currEnd);
        }

        // include days we are free after last meeting
        freeDays += days - prevEnd;
        return freeDays;
    }
}