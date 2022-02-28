public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var n = nums.Length;
        var result = new List<string>();
        
        if(n == 1){
            result.Add(nums[0].ToString());
            return result;
        }
        
        for(int i=0; i<n; i++){
            int a = nums[i];
            while(i+1 < n && (nums[i+1]-nums[i]) == 1) i++;
            
            if(a != nums[i]){
                result.Add(a + "->" + nums[i]);
            }
            else{
                result.Add(a.ToString());
            }
        }
        
        return result;
    }
}