// logic : for every positive number, put it in right index
// later check which pos number is not at right index
class Solution {
    public int firstMissingPositive(int[] nums) {
        var n = nums.length;
        for(var i=0; i<n; i++){
            while(nums[i] > 0 && nums[i] < n && nums[nums[i]-1] != nums[i]){
                var temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }

        for(var i=1; i<=n; i++){
            if(nums[i-1] != i)
                return i;
        }

        return n+1;
    }
}