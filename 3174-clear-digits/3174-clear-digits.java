class Solution {
    public String clearDigits(String s) {
        var alpha = new StringBuilder();
        for(var ch : s.toCharArray())
            if(Character.isDigit(ch))
                alpha.deleteCharAt(alpha.length()-1);   // alpha will always have something
            else
                alpha.append(ch);
        
        return alpha.toString();
    }
}