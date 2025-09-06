class Solution {
    public int makeTheIntegerZero(int num1, int num2) {
        if(num2 >= num1) return -1;
        var steps = 0;
        
        while(true){
            long num = num1 - (long)num2 * steps;
            if(num < steps) return -1;
            
            // check if remaining number is power of 2
            if(steps >= BitCount(num))
                return steps;
            
            steps++;
        }
    }

    private int BitCount(long n) {
        var count = 0;
        while (n != 0) {
            count += (n & 1);
            n >>= 1;
        }
        return count;
    }
}