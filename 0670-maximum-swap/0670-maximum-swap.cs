public class Solution {
    public int MaximumSwap(int num) {
        var str = num.ToString().ToCharArray();
        var n = str.Length;
        int smallIdx = n-1, largeIdx = n-1, largestIdx = n-1;

        for(var i=n-2; i >= 0; i--){
            if(str[i] > str[largestIdx])
                largestIdx = i;
            else if(str[i] < str[largestIdx]) {
                smallIdx = i;
                largeIdx = largestIdx;
            }
        }

        if(smallIdx == n-1) return num; // no change needed
        (str[smallIdx], str[largeIdx]) = (str[largeIdx], str[smallIdx]);
        return int.Parse(new String(str));
    }
}