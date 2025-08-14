class Solution {
    public String largestGoodInteger(String num) {
        var maxChar = '#';  // any char before 0 in ascii
        for(var i=0; i<=num.length()-3; i++){
            if(num.charAt(i) == num.charAt(i+1) && num.charAt(i) == num.charAt(i+2))
                maxChar = (char)Math.max(maxChar, num.charAt(i));
        }

        if(maxChar == '#') return "";
        var sb = new StringBuilder();
        sb.append(maxChar).append(maxChar).append(maxChar);
        return sb.toString();
    }
}