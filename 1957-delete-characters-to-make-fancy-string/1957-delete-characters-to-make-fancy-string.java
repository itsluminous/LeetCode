class Solution {
    public String makeFancyString(String s) {
        if(s.length() < 3) return s;

        char preprev = s.charAt(0);
        char prev = s.charAt(1);

        var sb = new StringBuilder();
        sb.append(preprev).append(prev);

        for(var i=2; i<s.length(); i++){
            var curr = s.charAt(i);
            if(curr == prev && curr == preprev) continue;
            
            sb.append(curr);
            preprev = prev;
            prev = curr;
        }

        return sb.toString();
    }
}