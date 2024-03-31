public class Solution {
    public int SumOfTheDigitsOfHarshadNumber(int x) {
        int og = x, sumOfDigits = 0;
        while(x != 0){
            sumOfDigits += x%10;
            x /= 10;
        }
        
        if(og % sumOfDigits == 0) return sumOfDigits;
        return -1;
    }
}