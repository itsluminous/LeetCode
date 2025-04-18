public class Solution {
    public string CountAndSay(int n) {
        var rle = "1";
        while(n-- > 1){
            var curr = new StringBuilder();
            
            for(var i=0; i<rle.Length; ){
                var ch = rle[i];
                var count = 1;
                while(++i < rle.Length && rle[i] == ch)
                    count++;
                curr.Append(count);
                curr.Append(ch);
            }
            rle = curr.ToString();
        }

        return rle;
    }
}