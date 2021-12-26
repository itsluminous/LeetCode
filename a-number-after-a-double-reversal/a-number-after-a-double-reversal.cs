public class Solution {
    public bool IsSameAfterReversals(int num) {
        if(num < 10) return true;           // single digit
        if(num % 10 == 0) return false;     // number ends with zero
        return true;                        // number ends with 1-9
    }
}