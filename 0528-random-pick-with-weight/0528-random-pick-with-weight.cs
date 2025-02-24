public class Solution {
    int[] pre;
    Random random;

    public Solution(int[] w) {
        // create prefixSum array
        for(var i=1; i<w.Length; i++)
            w[i] += w[i-1];
        
        pre = w;
        random = new Random();
    }
    
    public int PickIndex() {
        int min = 1, max = pre[^1];
        var val = random.Next(min, max + 1);
        return BinarySearch(val);
    }

    private int BinarySearch(int target){
        // using in-built
        // var idx = Array.BinarySearch(pre, target);
        // if(idx < 0) idx = ~idx;
        // return idx;

        int lo = 0, hi = pre.Length-1;
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
 * int param_1 = obj.PickIndex();
 */