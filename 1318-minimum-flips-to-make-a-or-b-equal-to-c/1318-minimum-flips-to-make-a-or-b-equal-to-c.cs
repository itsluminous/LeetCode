public class Solution {
    public int MinFlips(int a, int b, int c) {
        var flips = 0;
        while(a != 0 || b != 0 || c != 0){
            var abit = a & 1;
            a >>= 1;

            var bbit = b & 1;
            b >>= 1;

            var cbit = c & 1;
            c >>= 1;

            if((abit | bbit) != cbit && cbit == 0) flips += (abit + bbit);  // need to convert all 1 to 0
            else if((abit | bbit) != cbit) flips++;                         // make anyone as 1 will work
        }

        return flips;
    }
}