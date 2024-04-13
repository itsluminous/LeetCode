public class Solution {
    public int longestConsecutive(int[] nums) {
        var set = new HashSet<Integer>();
        for(var num : nums) set.add(num);

        var ans = 0;
        for(var num : set){
            if(set.contains(num-1)) continue;   // already processed, or will be eventually

            var count = 1;
            var currNum = num;
            while(set.contains(currNum+1)){
                count++;
                currNum++;
            }
            ans = Math.max(ans, count);
        }

        return ans;
    }
}