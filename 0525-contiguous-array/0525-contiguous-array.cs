// logic : treat 0 as -1
// every time we encounter 1 or 0, we do +1 or -1 in runningSum
// if runningSum is repeated, it means we have equal number of 1 & 0 in between
 
public class Solution {
    public int FindMaxLength(int[] nums) {
        int n = nums.Length, max = 0;

        // dict to maintain index of first occurrence of a sum
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict[0] = 0;

        var runningSum = 0;
        for(var i=0; i<n; i++){
            if(nums[i] == 0) runningSum--;
            else runningSum++;
            
            if(!dict.ContainsKey(runningSum)){
                dict[runningSum] = i+1;
                continue;
            }
            var gap = (i - dict[runningSum] + 1);
            max = Math.Max(max, gap);
        }

        return max;
    }
}