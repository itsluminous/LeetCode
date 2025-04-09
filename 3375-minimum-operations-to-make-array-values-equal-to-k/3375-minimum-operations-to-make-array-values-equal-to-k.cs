public class Solution {
    public int MinOperations(int[] nums, int k) {
        var uniq = new HashSet<int>();
        foreach(var num in nums){
            if(num < k) return -1;              // not possible to convert it to k
            else if(num > k) uniq.Add(num);     // all bigger nums need to be converted
        }

        return uniq.Count;
    }
}