class Solution {
    public String shiftingLetters(String s, int[][] shifts) {
        var n = s.length();
        var pre = new int[n+1];

        for(var shift : shifts){
            int start = shift[0], end = shift[1], dir = shift[2];
            if(dir == 0) dir = -1;
            pre[start] += dir;
            pre[end+1] -= dir;
        }

        var chars = s.toCharArray();
        var shift = 0;
        for(var i=0; i<n; i++){
            shift = (shift + pre[i]) % 26;
            if(shift < 0) shift += 26;

            var pos = (chars[i] - 'a' + shift) % 26;
            chars[i] = (char)('a' + pos);
        }

        return new String(chars);
    }
}