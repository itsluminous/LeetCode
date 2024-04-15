public class Solution {
    public int compress(char[] chars) {
        int n = chars.length, idx=0;
        
        var prev = chars[0];
        var count=1;
        for(var i=1; i<n; i++){
            if(chars[i] == prev) count++;
            else if(count == 1){
                chars[idx++] = prev;
                prev = chars[i];
            }
            else{
                chars[idx++] = prev;
                for(var ch : String.valueOf(count).toCharArray())
                    chars[idx++] = ch;
                count = 1;
                prev = chars[i];
            }
        }

        chars[idx++] = prev;
        if(count > 1)
            for(var ch : String.valueOf(count).toCharArray())
                chars[idx++] = ch;

        return idx;
    }
}