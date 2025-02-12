class Solution {
    public int[] rearrangeArray(int[] nums) {
        var len = nums.length;
        var result = new int[len];

        for(int i=0, p=0, n=1; i<len; i++){
            if(nums[i] < 0){
                result[n] = nums[i];
                n += 2;
            }
            else{
                result[p] = nums[i];
                p += 2;
            }
        }

        return result;
    }
}