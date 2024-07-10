class Solution {
    public int minOperations(String[] logs) {
        var depth = 0;
        for(var cmd : logs){
            if(cmd.equals("../") && depth > 0)
                depth--;
            else if(cmd.charAt(0) != '.')
                depth++;
        }
        return depth;
    }
}