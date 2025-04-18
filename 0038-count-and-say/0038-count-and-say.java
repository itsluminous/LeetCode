class Solution {
    public String countAndSay(int n) {
        var rle = "1";
        while(n-- > 1){
            var curr = new StringBuilder();
            
            for(var i=0; i<rle.length(); ){
                var ch = rle.charAt(i);
                var count = 1;
                while(++i < rle.length() && rle.charAt(i) == ch)
                    count++;
                curr.append(count);
                curr.append(ch);
            }
            rle = curr.toString();
        }

        return rle;
    }
}