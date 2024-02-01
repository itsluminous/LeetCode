public class Solution {
    public int[][] DivideArray(int[] nums, int k) {
        var n = nums.Length;
        if(n%3 != 0) return new int[0][];
        Array.Sort(nums);

        var result = new int[n/3][];
        for(int p=0, i=0; i<n; p++, i+=3){
            int num1 = nums[i], num2 = nums[i+1], num3 = nums[i+2];
            if(num3-num1 > k) return new int[0][];
            result[p] = new int[]{num1, num2, num3};
        }

        return result;
    }
}