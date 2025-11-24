public class Solution {
    public IList<bool> PrefixesDivBy5(int[] nums) {
        var ans = new List<bool>();
        var rem = 0;    // remainder
        foreach(var num in nums){
            rem <<= 1;
            rem |= num;
            rem %= 5;
            ans.Add(rem == 0);
        }
        return ans;
    }
}