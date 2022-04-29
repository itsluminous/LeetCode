public class Solution {
    public IList<int> Intersection(int[][] nums) {
        var n = nums.Length;
        var arr1 = nums[0].ToList();
        for(var i=1; i<n; i++){
            var arr2 = nums[i];
            arr1 = arr1.Intersect(arr2).ToList();
        }
        arr1.Sort();
        return arr1;
    }
}