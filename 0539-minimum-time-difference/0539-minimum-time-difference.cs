public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        const int MAX_MINS = 24 * 60;   // only 24 * 60 mins possible on clock
        var allMins = new bool[MAX_MINS];    

        // mark all minutes
        foreach(var time in timePoints){
            var totalMins = GetMins(time);
            if(allMins[totalMins]) return 0;  // already seen this time
            allMins[totalMins] = true;
        }

        // get smallest diff
        int smallest = int.MaxValue, largest = int.MinValue;
        int minDiff = int.MaxValue, prev = -MAX_MINS;
        for(var i=0; i<MAX_MINS; i++){
            if(!allMins[i]) continue;
            minDiff = Math.Min(minDiff, i - prev);
            smallest = Math.Min(smallest, i);
            largest = Math.Max(largest, i);
            prev = i;
        }

        // the two minutes on extreme end can be closer in the anti direction
        minDiff = Math.Min(minDiff, (MAX_MINS - largest + smallest));
        return minDiff;
    }

    private int GetMins(string time){
        var timeSplit = time.Split(":");
        var (hour, minute) = (int.Parse(timeSplit[0]), int.Parse(timeSplit[1]));
        return 60 * hour + minute;
    }
}