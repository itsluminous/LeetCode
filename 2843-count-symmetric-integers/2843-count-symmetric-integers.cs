public class Solution {
    public int CountSymmetricIntegers(int low, int high) {
        var count = 0;

        for(var num = low; num <= high; num++){
            if(num < 10 || (num >= 100 && num < 1000) || num == 10000) continue;  // odd digits

            // for two digit num, just check if both digits are equal
            if(num < 100){
                // left & right will be same if num % 11 == 0
                if(num % 11 == 0)
                    count++;
                continue;
            }

            // if we reached here, num is guaranteed to be 4 digits
            int left = num / 100, right = num % 100;
            int leftSum = left / 10 + left % 10;
            int rightSum = right / 10 + right % 10;
            if(leftSum == rightSum) count++;
        }

        return count;
    }
}