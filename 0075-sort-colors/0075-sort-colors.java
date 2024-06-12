class Solution {
    public void sortColors(int[] nums) {
        var freq = new int[3];
        for(var num : nums) freq[num]++;

        var idx = 0;
        for(var num=0; num<3; num++)
            for(var i=0; i<freq[num]; i++)
                nums[idx++] = num;
    }
}