// high 4 bits represent hour and low 6 bits represent minute
// because hour has 4 digits and min has 6 digits in watch
// with that idea, check each number upto 2^10
public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        var ans = new List<String>();
        for(var b=0; b < 1024; b++){
            var h = b >> 6;
            var m = b & 63; // 63 = 0000111111
            if(h < 12 && m < 60 && BitCount(b) == turnedOn)
                ans.Add(h + ":" + (m < 10 ? "0" : "") + m);
        }
        return ans;
    }

    private static int BitCount(int i) {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        i = (i + (i >> 4)) & 0x0f0f0f0f;
        i = i + (i >> 8);
        i = i + (i >> 16);
        return i & 0x3f;
    }
}