public class Solution {
    public int Compress(char[] chars) {
        int n = chars.Length, idx=0;
        
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
                foreach(var ch in count.ToString())
                    chars[idx++] = ch;
                count = 1;
                prev = chars[i];
            }
        }

        chars[idx++] = prev;
        if(count > 1)
            foreach(var ch in count.ToString())
                chars[idx++] = ch;

        return idx;
    }
}