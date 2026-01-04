public class Solution {
    public int[] PlusOne(int[] digits) {
        var n = digits.Length;
        for(var i=n-1; i>=0; i--){
            if(digits[i] < 9){
                digits[i]++;
                return digits;
            }
            digits[i] = 0;
        }

        // handle case where extra digit needs to be added
        var ans = new int[n+1];
        ans[0] = 1;
        return ans;
    }
}