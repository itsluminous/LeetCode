class Solution {
    public int getLucky(String s, int k) {
        var total = 0;
        for(var ch : s.toCharArray())
            total += digitSum((ch - 'a') + 1);
        
        while(k-- > 1)
            total = digitSum(total);

        return total;
    }

    private int digitSum(int num){
        var total = 0;
        while(num > 9){
            total += num % 10;
            num /= 10;
        }
        total += num;

        return total;
    }
}