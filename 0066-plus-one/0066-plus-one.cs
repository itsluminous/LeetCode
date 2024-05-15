public class Solution {
    public int[] PlusOne(int[] digits) {
        var carry = 1;
        for(var i=digits.Length-1; i>=0; i--){
            if(carry == 0) return digits;
            var num = digits[i] + carry;
            digits[i] = num % 10;
            carry = num / 10;
        }
        
        if(carry == 0) return digits;

        var ans = new int[digits.Length + 1];
        Array.Copy(digits, 0, ans, 1, digits.Length);
        ans[0] = carry;
        return ans;
    }
}