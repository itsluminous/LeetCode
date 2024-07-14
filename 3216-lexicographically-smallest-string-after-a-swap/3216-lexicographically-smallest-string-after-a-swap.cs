public class Solution {
    public string GetSmallestString(string s) {
        var chars = s.ToCharArray();
        for(var i=0; i<chars.Length-1; i++){
            if(chars[i] > chars[i+1]){
                var num1 = chars[i] - '0';
                var num2 = chars[i+1] - '0';
                if((num1 & 1) == (num2 & 1)){
                    (chars[i], chars[i+1]) = (chars[i+1], chars[i]);
                    break;
                }
            }
        }

        return new string(chars);
    }
}