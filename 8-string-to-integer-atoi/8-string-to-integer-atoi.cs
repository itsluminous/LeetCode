public class Solution {
    public int MyAtoi(string s) {
        int num = 0, sign = 1, idx = 0;
        var maxValBy10 = int.MaxValue/10;
        
        // skip leading space
        while(idx < s.Length && s[idx] == ' ') idx++;
        
        // check sign
        if(idx < s.Length && s[idx] == '+') idx++;
        else if(idx < s.Length && s[idx] == '-'){
            sign = -1;
            idx++;
        }
        // now read all numbers one by one
        while(idx < s.Length){
            // break out of loop if we find non-numeric character
            if(s[idx] < '0' || s[idx] > '9') break;
            // check for integer limit
            if(num > maxValBy10 || (num == maxValBy10 && s[idx] > '7'))
                return sign == -1 ? int.MinValue : int.MaxValue;
            // increment the num
            num = 10 * num + (s[idx] - '0');
            idx++;
        }
        
        return sign*num;
    }
}