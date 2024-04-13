public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>();
        foreach(var num in nums) set.Add(num);

        var ans = 0;
        foreach(var num in set){
            if(set.Contains(num-1)) continue;   // already processed, or will be eventually

            var count = 1;
            var currNum = num;
            while(set.Contains(currNum+1)){
                count++;
                currNum++;
            }
            ans = Math.Max(ans, count);
        }

        return ans;
    }
}