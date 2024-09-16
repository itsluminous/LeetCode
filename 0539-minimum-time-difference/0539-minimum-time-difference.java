class Solution {
    public int findMinDifference(List<String> timePoints) {
        int MAX_MINS = 24 * 60;   // only 24 * 60 mins possible on clock
        var allMins = new boolean[MAX_MINS];    

        // mark all minutes
        for(var time : timePoints){
            var totalMins = getMins(time);
            if(allMins[totalMins]) return 0;  // already seen this time
            allMins[totalMins] = true;
        }

        // get smallest diff
        int smallest = Integer.MAX_VALUE, largest = Integer.MIN_VALUE;
        int minDiff = Integer.MAX_VALUE, prev = -MAX_MINS;
        for(var i=0; i<MAX_MINS; i++){
            if(!allMins[i]) continue;
            minDiff = Math.min(minDiff, i - prev);
            smallest = Math.min(smallest, i);
            largest = Math.max(largest, i);
            prev = i;
        }

        // the two minutes on extreme end can be closer in the anti direction
        minDiff = Math.min(minDiff, (MAX_MINS - largest + smallest));
        return minDiff;
    }

    private int getMins(String time){
        var timeSplit = time.split(":");
        var hour = Integer.parseInt(timeSplit[0]);
        var minute = Integer.parseInt(timeSplit[1]);
        return 60 * hour + minute;
    }
}