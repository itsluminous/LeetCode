class Solution {
    public int countOperations(int num1, int num2) {
        var ans = 0;

        while(num1 != 0 && num2 != 0) {
            ans += num1 / num2; //  we may have to subtract num2 multiple times, so taking shortcut
            num1 %= num2;

            // swap numbers
            var temp = num1;
            num1 = num2;
            num2 = temp;
        }

        return ans;
    }
}