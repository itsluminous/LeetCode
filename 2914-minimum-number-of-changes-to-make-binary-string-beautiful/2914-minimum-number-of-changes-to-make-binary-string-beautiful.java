class Solution {
    public int minChanges(String s) {
        var count = 0;
        for(var i=1; i<s.length(); i+=2)
            if(s.charAt(i) != s.charAt(i-1))
                count++;
        
        return count;
    }
}