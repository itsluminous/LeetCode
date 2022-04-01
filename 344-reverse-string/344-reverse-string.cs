public class Solution {
    public void ReverseString(char[] s) {
        var n = s.Length;
        for(int i=0, j=n-1; i<j; i++, j--){
            var temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }
    }
}