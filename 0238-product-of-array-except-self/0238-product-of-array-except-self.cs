public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length, leftProd = 1,rightProd = 1;

        var result = new int[n];
        result[0] = leftProd;

        // calculate all left prod
        for(var i=1; i<n; i++){
            leftProd *= nums[i-1];
            result[i] = leftProd;
        }

        // calculate right prod and update result
        for(var i=n-2; i>=0; i--){
            rightProd *= nums[i+1];
            result[i] *= rightProd;
        }

        return result;
    }
}

// using 2 array
public class Solution2Arr {
    public int[] ProductExceptSelf(int[] nums) {
        var n = nums.Length;
        int[] leftProd = new int[n], rightProd = new int[n], result = new int[n];
        leftProd[0] = rightProd[n-1] = 1;

        for(int i=1, j=n-2; i<n; i++, j--){
            leftProd[i] = leftProd[i-1]*nums[i-1];
            rightProd[j] = rightProd[j+1]*nums[j+1];
        }

        result[0] = rightProd[0];
        result[n-1] = leftProd[n-1];
        for(var i=1; i<n-1; i++)
            result[i] = leftProd[i] * rightProd[i];

        return result;
    }
}