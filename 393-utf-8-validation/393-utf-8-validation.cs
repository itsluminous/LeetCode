public class Solution {
    public bool ValidUtf8(int[] data) {
        var bytecount = 0;
        foreach(var d in data){
            var binary = Convert.ToString(d, 2).PadLeft(8, '0');
            if(bytecount == 0){     // this is start of sequence
                foreach(var ch in binary){
                    if(ch == '1') bytecount++;
                    else break;
                }
                if(bytecount == 1 || bytecount > 4) return false;   // invalid case. bytecount values can only be 0, 2, 3, 4
                bytecount = bytecount > 0 ? bytecount-1 : bytecount;    // for more than 1 bytes, we have already consumed 1 byte
            }
            else{
                if(!binary.StartsWith("10")) return false;      // a subsequent byte should always start with "10"
                bytecount--;
            }
        }
        if(bytecount != 0) return false;    // last sequence was not complete
        return true;
    }
}