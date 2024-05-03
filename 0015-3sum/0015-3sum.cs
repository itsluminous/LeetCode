public class Solution {
    IList<IList<int>> ans = new List<IList<int>>();
    
    public IList<IList<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        kSum(nums, 0, 3, 0, new List<int>());
        return ans;
    }

    public void kSum(int[] nums, long target, int k, int idx, List<int> curr) {
        if(idx + k > nums.Length) return;
        
        // need to reduce problem to two sum
        if(k > 2){
            for(var i=idx; i<nums.Length; i++){
                if(i > idx && nums[i] == nums[i-1]) continue;   // skip repeated numbers
                
                curr.Add(nums[i]);
                kSum(nums, target-nums[i], k-1, i+1, curr);
                curr.RemoveAt(curr.Count-1);
            }
        }
        // two-sum code
        else{
            int left = idx, right = nums.Length-1;
            while(left < right){
                var currSum = nums[left] + nums[right];
                if(currSum == target) {
                    var clone = new List<int>(curr);
                    clone.AddRange([nums[left], nums[right]]);
                    ans.Add(clone);
                    while(left < right && nums[left] == nums[left + 1]) left++;     // skip repeated numbers
                    while(left < right && nums[right] == nums[right - 1]) right--;  // skip repeated numbers
                    left++;
                    right--;
                } 
                else if (currSum < target) left++;
                else right--;
            }
        }
    }
}