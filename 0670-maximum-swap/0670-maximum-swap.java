class Solution {
    public int maximumSwap(int num) {
        var str = Integer.toString(num).toCharArray();
        var n = str.length;
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
        var tmp = str[smallIdx];
        str[smallIdx] = str[largeIdx];
        str[largeIdx] = tmp;
        return Integer.valueOf(new String(str));
    }
}