public class Solution {
    public int GetLucky(string s, int k) {
        var total = 0;
        foreach(var ch in s)
            total += DigitSum((ch - 'a') + 1);
        
        while(k-- > 1)
            total = DigitSum(total);

        return total;
    }

    private int DigitSum(int num){
        var total = 0;
        while(num > 9){
            total += num % 10;
            num /= 10;
        }
        total += num;

        return total;
    }
}