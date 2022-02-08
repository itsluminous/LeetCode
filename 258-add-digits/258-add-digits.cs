// O(1) - To understand it, look up explaination for "Digital Root"
public class Solution {
    public int AddDigits(int num) {
        if(num == 0) return 0;
        if(num %9 == 0) return 9;   // if number is divisible by 9
        return num % 9;             // if number is not divisible by 9
    }
}

// Accepted - Not O(1)
public class Solution1 {
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