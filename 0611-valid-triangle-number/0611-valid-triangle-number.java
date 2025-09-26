class Solution {
    public int triangleNumber(int[] nums) {
        int n = nums.length, count = 0;
        Arrays.sort(nums);
        
        for(var k = n-1; k > 1; k--) {
            int i = 0, j = k - 1;
            while (i < j) {
                // condition for a triangle is that nums[i] + nums[j] > nums[k]
                if (nums[i] + nums[j] > nums[k]) {
                    count += j - i;
                    j--;
                } else {
                    i++;
                }
            }
        }

        return count;
    }
}