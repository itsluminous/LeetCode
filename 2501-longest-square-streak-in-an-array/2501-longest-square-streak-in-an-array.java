class Solution {
    public int longestSquareStreak(int[] nums) {
        var streaks = new HashMap<Integer, Integer>(); // key = number, val = longest streak including it
        var longestStreak = 0;

        Arrays.sort(nums);
        for(var num : nums){
            var sq = Math.sqrt(num);
            var sqf = (int)Math.floor(sq);

            // if it is a whole number
            if(sq == sqf && streaks.containsKey(sqf)){
                streaks.put(num, streaks.get(sqf) + 1);
                longestStreak = Math.max(longestStreak, streaks.get(num));
            }
            else
                streaks.put(num, 1);
        }

        if(longestStreak > 1) return longestStreak;
        return -1;
    }
}