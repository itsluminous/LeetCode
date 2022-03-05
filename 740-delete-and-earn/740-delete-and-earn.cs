public class Solution {
    public int DeleteAndEarn(int[] nums) {
        var arr = new int[20001];
        for(int i=0; i< nums.Length; i++){
            arr[nums[i]] += nums[i];
        }
        
        int take = 0, leave = 0;
        for(int i=0; i< arr.Length; i++){
            var takeIt = leave + arr[i];
            leave = Math.Max(take, leave);
            take = takeIt;
        }
        return Math.Max(take, leave);
    }
}