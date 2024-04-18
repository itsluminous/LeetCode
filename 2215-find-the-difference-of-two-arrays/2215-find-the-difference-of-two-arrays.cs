public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        var n1 = nums1.Distinct().Except(nums2).ToList();
        var n2 = nums2.Distinct().Except(nums1).ToList();
        return new List<IList<int>>{n1, n2};
    }
}