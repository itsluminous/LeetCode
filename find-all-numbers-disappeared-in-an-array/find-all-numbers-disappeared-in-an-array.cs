// O(n) - no sorting
public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        var n = nums.Length;
        
        // loop 1 : mark all indexes which are present by making them negative
        for(var i=0; i<n; i++) {
            int m = Math.Abs(nums[i])-1;     // index start from 0 hence -1
            nums[m] = nums[m] > 0 ? -nums[m] : nums[m];     // we want to keep nums[m] negative
        }
        
        var result = new List<int>();
        for(var i = 0; i<n; i++) {
            if(nums[i] > 0)         // if no one marked it negative in above loop
                result.Add(i+1);    // +1 because i is index, we want number
        }
        return result;
    }
}

// Accepted - using sorting
public class Solution1 {
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
