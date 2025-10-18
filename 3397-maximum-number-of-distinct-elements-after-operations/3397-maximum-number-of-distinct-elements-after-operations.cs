public class Solution {
    public int MaxDistinctElements(int[] nums, int k) {
        Array.Sort(nums);
        var ans = 0;
        var prev = int.MinValue;
        foreach(var num in nums){
            var curr = Math.Min(Math.Max(prev + 1, num - k), num + k);
            if(curr > prev){
                ans++;
                prev = curr;
            }
        }
        return ans;
    }
}