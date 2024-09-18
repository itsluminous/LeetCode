public class Solution {
    public string LargestNumber(int[] nums) {
        // handle edge case - when all numbers are 0, then return single 0
        if(nums.All(num => num == 0)) return "0";

        // convert array to string
        var strNums = nums.Select(num => num.ToString()).ToArray();

        // sort the strings with custom logic
        Array.Sort(strNums, (s1, s2) => (s2+s1).CompareTo(s1+s2));

        // join all the strings
        return string.Concat(strNums);
    }
}