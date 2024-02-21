public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        // intuition : if two numbers are not equal
        // then AND of last bit would always be zero for all numbers in between them
        // this is because last bit is always different between two consecutive numbers
        // and doing AND on last bit for two consecutive numbers will always be 0
        
        var shift = 0; // to count how many bits are 0 on the right
        while(left != right){
            // if numbers are not equal, shift right by one position
            left >>= 1;
            right >>= 1;
            shift++;  
        }  
        
        // once the numbers become equal, add 0's as many times as we shifted
        return left << shift;  
    }
}

// Time Limit Exceeded
public class Solution1 {
    public int RangeBitwiseAnd(int left, int right) {
        var num = left;
        for(var i=left+1; i<=right; i++)
            num &=i;
        
        return num;
    }
}