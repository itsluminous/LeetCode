/**
 * @param {number[]} nums
 * @return {number}
 */
var removeDuplicates = function(nums) {
    var left = right = 0;
    seen = [];

    while(right < nums.length){
        if(!seen[nums[right] + 100]){
            nums[left++] = nums[right];
            seen[nums[right] + 100] = true;
        }
        right++;
    }
    return left;
};