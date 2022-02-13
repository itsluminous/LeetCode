// Add smallest first
public class Solution {
    List<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> Subsets(int[] nums) {
        result.Add(new List<int>());
        for(var i=0; i<nums.Length; i++)
            Subsets(nums, i, new List<int>{nums[i]});
        return result;
    }
    
    private void Subsets(int[] nums, int idx, List<int> list) {result.Add(new List<int>(list));
        for(var i=idx+1; i<nums.Length; i++){
            list.Add(nums[i]);
            Subsets(nums, i, list);
            list.RemoveAt(list.Count - 1);
        }
    }
}

// Accepted - add biggest first
public class Solution1 {
    IList<IList<int>> result = new List<IList<int>>();
    public IList<IList<int>> Subsets(int[] nums) {
        result.Add(new List<int>());        // Empty array is always an answer
        Subsets(nums, 0, nums.Length, new List<int>());     // Now find all possible combinations
        return result;
    }
    
    private void Subsets(int[] nums, int start, int end, IList<int> list){
        // first we go to max possible length, then add it to list and then backtrack
        for(int i=start; i<end; i++){
            list.Add(nums[i]);
            Subsets(nums, i+1, end, list);
            result.Add(new List<int>(list));
            list.RemoveAt(list.Count-1);
        }
    }
}