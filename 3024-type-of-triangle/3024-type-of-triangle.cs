public class Solution {
    public string TriangleType(int[] nums) {
        Array.Sort(nums);
        int s1 = nums[0], s2 = nums[1], s3 = nums[2];

        if(s1 + s2 <= s3) return "none";  // can't form triangle
        if(s1 == s3) return "equilateral";
        if(s1 == s2 || s2 == s3) return "isosceles";
        return "scalene";
    }
}