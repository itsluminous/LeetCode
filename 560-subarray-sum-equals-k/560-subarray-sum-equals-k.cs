public class Solution {
    public int SubarraySum(int[] nums, int k) {
        int n = nums.Length, count = 0, sum = 0;
        var dict = new Dictionary<int,int>();
        dict[0] = 1;    // one occurence of 0
        
        foreach(var num in nums){
            sum += num;
            if(dict.ContainsKey(sum-k)) count += dict[sum-k];
            if(!dict.ContainsKey(sum)) dict[sum] = 0;
            dict[sum]++;
        }
        
        return count;
    }
}