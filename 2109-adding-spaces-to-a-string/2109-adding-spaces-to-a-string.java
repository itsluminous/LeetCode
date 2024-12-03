class Solution {
    public String addSpaces(String s, int[] spaces) {
        var sb = new StringBuilder();
        int idx = 0, maxIdx = spaces.length;
        for(var i=0; i<s.length(); i++){         
            if(idx < maxIdx && i == spaces[idx]){
                sb.append(" ");
                idx += 1;
            }    
            sb.append(s.charAt(i));
        }
        
        return sb.toString();
    }
}