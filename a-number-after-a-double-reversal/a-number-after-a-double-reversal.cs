// one liner
public class Solution {
    public bool IsSameAfterReversals(int num) {
        return num == 0 || num % 10 > 0;
    }
}

// Accepted - more detailed
public class Solution1 {
    public bool IsSameAfterReversals(int num) {
        if(num < 10) return true;           // single digit
        if(num % 10 == 0) return false;     // number ends with zero
        return true;                        // number ends with 1-9
    }
}
