public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        // step 1 : convert array to set
        HashSet<int> set1 = new HashSet<int>(), set2 = new HashSet<int>();
        foreach(var n1 in nums1) set1.Add(n1);
        foreach(var n2 in nums2) set2.Add(n2);
        
        // step 2 : remove all repeating numbers
        foreach(var k in set1){
            if(set2.Contains(k)){
                set1.Remove(k);
                set2.Remove(k);
            }
        }
        
        // step 3 : return the sets
        return new List<IList<int>>{set1.ToList(), set2.ToList()};
    }
}