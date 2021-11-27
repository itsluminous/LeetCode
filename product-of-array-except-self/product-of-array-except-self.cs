/*
Solution with no division

copied explaination from here - https://leetcode.com/problems/product-of-array-except-self/discuss/65622/Simple-Java-solution-in-O(n)-without-extra-space/67603

Given numbers [2, 3, 4, 5], regarding the third number 4, the product of array except 4 is 2*3*5 which consists of two parts: left 2*3 and right 5. The product is left*right. We can get lefts and rights:

Numbers:     2    3    4     5
Lefts:            2  2*3 2*3*4
Rights:  3*4*5  4*5    5      
Let’s fill the empty with 1:

Numbers:     2    3    4     5
Lefts:       1    2  2*3 2*3*4
Rights:  3*4*5  4*5    5     1
We can calculate lefts and rights in 2 loops. The time complexity is O(n).

We store lefts in result array. If we allocate a new array for rights. The space complexity is O(n). To make it O(1), we just need to store it in a variable which is right in @lycjava3’s code.
*/
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        var result = new int[n];
        int left = 1, right = 1;
        
        // Store all the left products
        result[0] = left;
        for(var i=1; i<n; i++){
            left *= nums[i-1];
            result[i] = left;
        }
        
        // Store all the right products
        // result[n-1] has no right, so it already has correct value
        for(var i=n-2; i>=0; i--){
            right *= nums[i+1];
            result[i] *= right;
        }
        return result;
    }
}

// Simple
public class Solution1 {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        var product = nums[0];
        var zeroes = 0;     // needed to handle divide by zero error
        for(var i=1; i<n; i++){
            if(nums[i] == 0){
                zeroes++;
                continue;
            }
            product *= nums[i];
        }
            
        
        var result = new int[n];
        for(var i=0; i<n; i++){
            if(nums[i] == 0)
                result[i] = zeroes == 1 ? product : 0;
            else
                result[i] = zeroes == 0 ? product/nums[i] : 0;
        }
        
        return result;
    }
}