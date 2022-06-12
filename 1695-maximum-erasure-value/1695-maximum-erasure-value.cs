public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int l=0, r=1, n=nums.Length, sum=nums[0], max=nums[0];
        var set = new HashSet<int>();
        set.Add(nums[0]);
        
        for(r=1; r<n; r++){
            if(!set.Add(nums[r])){
                max = Math.Max(max, sum);
                do{
                    set.Remove(nums[l]);
                    sum -= nums[l];
                    l++;
                }while(!set.Add(nums[r]));
            }
            sum += nums[r];
        }
        
        return Math.Max(max, sum);
    }
}