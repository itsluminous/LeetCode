class Solution {
    public List<Boolean> prefixesDivBy5(int[] nums) {
        var ans = new ArrayList<Boolean>();
        var rem = 0;    // remainder
        for(var num : nums){
            rem <<= 1;
            rem |= num;
            rem %= 5;
            ans.add(rem == 0);
        }
        return ans;
    }
}