public class Solution {
    public bool JudgeSquareSum(int c) {
        for(long num1 = 0; num1 * num1 <= c; num1++){
            var num2sq = c - num1*num1;
            // if this number is a perfect square, then we have a match
            var num2root = Math.Sqrt(num2sq);
            if((int)num2root == num2root) return true;
        }
        return false;
    }
}