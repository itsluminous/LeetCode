public class Solution {
    public string ShiftingLetters(string s, int[][] shifts) {
        var n = s.Length;
        var pre = new int[n+1];

        foreach(var shft in shifts){
            int start = shft[0], end = shft[1], dir = shft[2];
            if(dir == 0) dir = -1;
            pre[start] += dir;
            pre[end+1] -= dir;
        }

        var chars = s.ToCharArray();
        var shift = 0;
        for(var i=0; i<n; i++){
            shift = (shift + pre[i]) % 26;
            if(shift < 0) shift += 26;

            var pos = (chars[i] - 'a' + shift) % 26;
            chars[i] = (char)('a' + pos);
        }

        return new string(chars);
    }
}