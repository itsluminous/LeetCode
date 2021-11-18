public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var n = nums.Length;
        Array.Sort(nums);
        
        var result = new List<int>();
        var prev = 1;
        for(var i=0; i<n; i++){
            if(i!=0 && nums[i] == nums[i-1]) continue;  // if same as last no., we have processed it
            if(nums[i] < prev) continue;                // if smaller than expected no, we don't have to check anything
            
            // add all the numbers between current and previous number
            while(nums[i] > prev){
                result.Add(prev);
                prev++;
            }
            prev++;
        }
        
        // add all the numbers left after last number
        while(n >= prev){
            result.Add(prev);
            prev++;
        }
        
        return result;
    }
}