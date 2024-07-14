class Solution {
    public String getSmallestString(String s) {
        var chars = s.toCharArray();
        for(var i=0; i<chars.length-1; i++){
            if(chars[i] > chars[i+1]){
                var num1 = chars[i] - '0';
                var num2 = chars[i+1] - '0';
                if((num1 & 1) == (num2 & 1)){
                    var tmp = chars[i];
                    chars[i] = chars[i+1];
                    chars[i+1] = tmp;
                    break;
                }
            }
        }

        return new String(chars);
    }
}