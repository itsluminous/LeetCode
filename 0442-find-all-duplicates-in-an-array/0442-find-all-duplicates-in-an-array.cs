// no extra space needed
// mark a particular index as negative if we see it first time
public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        var result = new List<int>();
        foreach(var num in nums){
            var abs = Math.Abs(num);
            if(nums[abs-1] < 0) result.Add(abs);
            else nums[abs-1]  *= -1;
        }
        return result;
    }
}

// Accepted - using extra array
public class SolutionArr {
    public IList<int> FindDuplicates(int[] nums) {
        var found = new bool[1_00_001];
        var result = new List<int>();
        foreach(var num in nums)
            if(found[num]) result.Add(num);
            else found[num] = true;
        
        return result;
    }
}