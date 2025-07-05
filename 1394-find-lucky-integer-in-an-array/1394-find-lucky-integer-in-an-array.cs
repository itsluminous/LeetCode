public class Solution {
    public int FindLucky(int[] arr) {
        var freq = new int[501];
        foreach(var num in arr) freq[num]++;
        
        for(var i=500; i>0; i--)
            if(freq[i] == i) return i;
        return -1;
    }
}