class Solution {
    public int binaryGap(int n) {
        int maxDiff = 0, currDiff = -32;
        while(n > 0){
            if((n & 1) == 0) currDiff++;
            else {
                maxDiff = Math.max(maxDiff, currDiff);
                currDiff = 1;
            }
            n >>= 1;
        }
        return Math.max(maxDiff, 0);
    }
}