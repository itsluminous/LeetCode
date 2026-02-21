public class Solution {
    public bool HasAlternatingBits(int n) {
        var prev = 100; // anything random
        while(n != 0){
            var curr = (n & 1);
            if(prev == curr) return false;
            prev = curr;
            n >>= 1;
        }
        return true;
    }
}