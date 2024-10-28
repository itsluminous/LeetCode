public class Solution {
    public int LongestSquareStreak(int[] nums) {
        var streaks = new Dictionary<int, int>(); // key = number, val = longest streak including it
        var longestStreak = 0;

        Array.Sort(nums);
        foreach(var num in nums){
            var sq = Math.Sqrt(num);
            var sqf = (int)Math.Floor(sq);

            // if it is a whole number
            if(sq == sqf && streaks.ContainsKey(sqf)){
                streaks[num] = streaks[sqf] + 1;
                longestStreak = Math.Max(longestStreak, streaks[num]);
            }
            else
                streaks[num] = 1;
        }

        if(longestStreak > 1) return longestStreak;
        return -1;
    }
}