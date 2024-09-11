public class Solution {
    public int MinBitFlips(int start, int goal) {
        var delta = start ^ goal;
        var flips = 0;
        while(delta != 0){
            flips += delta & 1;
            delta >>= 1;
        }
        return flips;
    }
}