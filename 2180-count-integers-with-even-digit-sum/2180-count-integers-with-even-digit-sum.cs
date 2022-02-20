// O(n)
public class Solution {
    public int CountEven(int num) {
        int temp = num, sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        // if sum is even, then half of them are ans, else one less
        return sum % 2 == 0 ? temp/2 : (temp-1)/2;
    }
}


// Accepted - O(n^2)
public class Solution1 {
    public int CountEven(int num) {
        var count = 0;
        for(var i=2; i<=num; i++){
            if(DigitSum(i) % 2 == 0) count++;
        }
        
        return count;
    }
    
    private int DigitSum(int num){
        var sum = 0;
        while(num > 0){
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}