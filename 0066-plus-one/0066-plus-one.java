class Solution {
    public int[] plusOne(int[] digits) {
        var carry = 1;
        for(var i=digits.length-1; i>=0; i--){
            if(carry == 0) return digits;
            var num = digits[i] + carry;
            digits[i] = num % 10;
            carry = num / 10;
        }
        
        if(carry == 0) return digits;

        var ans = new int[digits.length + 1];
        System.arraycopy(digits, 0, ans, 1, digits.length);
        ans[0] = carry;
        return ans;
    }
}