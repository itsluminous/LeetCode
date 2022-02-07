public class Solution {
    public int[] SortEvenOdd(int[] nums) {
        List<int> oddIndices = new List<int>(), evenIndices = new List<int>();
        var n = nums.Length;
        
        // step 1 : populate even and odd indices in separate array/list
        for(var i=0; i<n; i++){
            if(i%2 == 0) evenIndices.Add(nums[i]);
            else oddIndices.Add(nums[i]);
        }
        
        // step 2 : sort the two collections
        var evenAscending = evenIndices.OrderBy(i => i).ToList();
        var oddDescending = oddIndices.OrderByDescending(i => i).ToList();
        
        // step 3 : merge them
        for(int i=0, j=0; i<n; i+=2)  nums[i] =  evenAscending[j++];
        for(int i=1, j=0; i<n; i+=2)  nums[i] =  oddDescending[j++];
        
        return nums;
    }
}