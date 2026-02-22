public class Solution {
    public int BinaryGap(int n) {
        int maxDiff = 0, currDiff = -32;
        while(n > 0){
            if((n & 1) == 0) currDiff++;
            else {
                maxDiff = Math.Max(maxDiff, currDiff);
                currDiff = 1;
            }
            n >>= 1;
        }
        return Math.Max(maxDiff, 0);
    }
}