public class Solution {
    public int Reverse(int x) {
        var ans = 0;
        const int min = int.MinValue/10, max = int.MaxValue/10;

        while(x != 0){
            if(ans > max || ans < min) return 0;

            var digit = x % 10;
            x /= 10;
            ans = ans * 10 + digit;
        }
        return ans;
    }
}