public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        HashSet<int> num1Set = new(), num2Set = new();
        int count1 = 0, count2 = 0;

        foreach(var num in nums1) num1Set.Add(num);
        foreach(var num in nums2) num2Set.Add(num);

        foreach(var num in nums1)
            if(num2Set.Contains(num)) count1++;

        foreach(var num in nums2)
            if(num1Set.Contains(num)) count2++;

        return [count1, count2];
    }
}