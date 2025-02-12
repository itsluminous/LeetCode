class Solution {
    public int majorityElement(int[] nums) {
        int majElem = nums[0], majCount = 1;

        for(var i=1; i<nums.length; i++){
            if(nums[i] == majElem)
                majCount++;
            else if(majCount == 1){
                majElem = nums[i];
                majCount = 1;
            }
            else
                majCount--;
        }

        return majElem;
    }
}