public class Solution {
    public int reverse(int x) {
        var ans = 0;
        final int min = Integer.MIN_VALUE/10, max = Integer.MAX_VALUE/10;

        while(x != 0){
            if(ans > max || ans < min) return 0;

            var digit = x % 10;
            x /= 10;
            ans = ans * 10 + digit;
        }
        return ans;
    }
}