public class Solution {
    public int AddDigits(int num) {
        while(num >= 10){
            var sum = 0;
            do{
                sum += num % 10;
                num = num / 10;
            } while (num > 0);
            num = sum;
        }
        return num;
    }
}