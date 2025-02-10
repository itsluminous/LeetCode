class Solution {
    public int removeDuplicates(int[] nums) {
        var k = 1;
        for(var i=1; i < nums.length; i++){
            if(nums[i] != nums[i-1])
                nums[k++] = nums[i];
        }
        return k;
    }
}