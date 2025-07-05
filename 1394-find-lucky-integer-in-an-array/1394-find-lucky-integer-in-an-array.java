class Solution {
    public int findLucky(int[] arr) {
        var freq = new int[501];
        for(var num : arr) freq[num]++;
        
        for(var i=500; i>0; i--)
            if(freq[i] == i) return i;
        return -1;
    }
}