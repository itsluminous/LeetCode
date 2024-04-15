class Solution {
    public int[] productExceptSelf(int[] nums) {
        var n = nums.length;
        var result = new int[n];
        result[0] = 1;

        // calculate all products from left
        var prod = 1;
        for(var i=1; i<n; i++){
            prod *= nums[i-1];
            result[i] = prod;
        }

        // calculate all products from right
        prod = 1;
        for(var i=n-2; i>=0; i--){
            prod *= nums[i+1];
            result[i] *= prod;
        }

        return result;
    }
}