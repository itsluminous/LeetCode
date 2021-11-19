public class Solution {
    public int HammingDistance(int x, int y) {
        var xored = x^y;
        var hd = 0;
        while(xored != 0){
            hd += xored&1;      // check if last bit is one
            xored = xored>>1;   // right shift by 1, for next loop
        }
        return hd;
    }
}