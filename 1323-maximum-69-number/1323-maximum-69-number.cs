public class Solution {
    public int Maximum69Number (int num) {
        var mask = GetMask(num);    // for number like 9669, mask will be 1000
        var ans = 0;
        var flip = false;   // has flip been done?

        while(num > 0){
            var digit = num / mask;
            if(!flip && digit == 6){
                ans += mask * 9;
                flip = true;
            }
            else
                ans += mask * digit;
            
            num = (num % (digit * mask));
            mask /= 10;
        }

        return ans;
    }

    private int GetMask(int num){
        var mask = 1;
        while(num >= 10){
            num /= 10;
            mask *= 10;
        }
        return mask;
    }
}