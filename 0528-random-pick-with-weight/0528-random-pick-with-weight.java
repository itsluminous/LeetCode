class Solution {
    int[] pre;
    Random random;

    public Solution(int[] w) {
        // create prefixSum array
        for(var i=1; i<w.length; i++)
            w[i] += w[i-1];
        
        pre = w;
        random = new Random();
    }
    
    public int pickIndex() {
        int min = 1, max = pre[pre.length-1];
        var val = random.nextInt(min, max + 1);
        return BinarySearch(val);
    }

    private int BinarySearch(int target){
        int lo = 0, hi = pre.length-1;
        while(lo < hi){
            var mid = lo + (hi - lo)/2;
            if(pre[mid] < target) lo = mid+1;
            else hi = mid;
        }

        return lo;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.pickIndex();
 */