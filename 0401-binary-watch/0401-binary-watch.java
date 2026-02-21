// high 4 bits represent hour and low 6 bits represent minute
// because hour has 4 digits and min has 6 digits in watch
// with that idea, check each number upto 2^10
class Solution {
    public List<String> readBinaryWatch(int turnedOn) {
        var ans = new ArrayList<String>();
        for(var b=0; b < 1024; b++){
            var h = b >> 6;
            var m = b & 63; // 63 = 0000111111
            if(h < 12 && m < 60 && Integer.bitCount(b) == turnedOn)
                ans.add(h + ":" + (m < 10 ? "0" : "") + m);
        }
        return ans;
    }
}