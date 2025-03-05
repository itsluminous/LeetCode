class Solution {
    public int maxChunksToSorted(int[] arr) {
        int n = arr.length, chunks = 0;
        
        // min number seen on right side
        var minOnRight = new int[n];
        minOnRight[n-1] = arr[n-1];
        for(var i = n - 2; i >= 0; i--)
            minOnRight[i] = Math.min(arr[i], minOnRight[i+1]);
        
        var maxOnLeft = 0;   // max number seen on left side
        for(var i = 0; i < n - 1; i++){
            maxOnLeft = Math.max(maxOnLeft, arr[i]);
            if(maxOnLeft <= minOnRight[i+1])
                chunks++;
        }
        
        return 1 + chunks;   // add 1 because our loop does not include last element
    }
}