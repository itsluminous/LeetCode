// approach : https://leetcode.com/problems/maximum-sum-of-subsequence-with-non-adjacent-elements/solutions/5208917/segment-tree/

// each node in seg tree will have to maintain 4 values, so that we can apply house robber algo
// [0][0] : leftmost & rightmost in curr range is not selected
// [0][1] : leftmost in curr range is not selected, rightmost is selected
// [0][0] : leftmost in curr range is selected, rightmost is not selected
// [0][0] : leftmost & rightmost in curr range are both selected

class Solution {
    public int maximumSumSubsequence(int[] nums, int[][] queries) {
        var MOD = 1_000_000_007;
        var segTree = new Node(nums, 0, nums.length - 1);
        long res = 0;

        for(var query : queries){
            segTree.update(query[0], query[1]);
            res += segTree.getMaxSum();
            res %= MOD;
        }
        return (int)res;
    }
}

class Node {
    long inf = (long) 1e18;
    Node l = null, r = null;
    int lo, hi;
    long[][] selected = new long[2][2];

    public Node(int[] nums, int lo, int hi){
        this.lo = lo;
        this.hi = hi;

        if(lo < hi){
            var mid = (lo + hi) / 2;
            l = new Node(nums, lo, mid);
            r = new Node(nums, mid+1, hi);
            combine();
        }
        else{
            selected[0][0] = 0;
            selected[0][1] = -inf;
            selected[1][0] = -inf;
            selected[1][1] = nums[lo];  // same as nums[hi]
        }
    }

    // house robber algo
    private void combine(){
        selected[0][0] = Math.max(l.selected[0][0] + r.selected[0][0], 
                         Math.max(l.selected[0][1] + r.selected[0][0], l.selected[0][0] + r.selected[1][0]));
        selected[0][1] = Math.max(l.selected[0][0] + r.selected[0][1], 
                         Math.max(l.selected[0][1] + r.selected[0][1], l.selected[0][0] + r.selected[1][1]));
        selected[1][0] = Math.max(l.selected[1][0] + r.selected[0][0], 
                         Math.max(l.selected[1][1] + r.selected[0][0], l.selected[1][0] + r.selected[1][0]));
        selected[1][1] = Math.max(l.selected[1][0] + r.selected[0][1], 
                         Math.max(l.selected[1][1] + r.selected[0][1], l.selected[1][0] + r.selected[1][1]));
    }

    public void update(int idx, long val){
        if(idx < lo || idx > hi) return;

        // reached root node
        if(lo == hi){
            selected[0][0] = 0;
            selected[1][1] = val;
            return;
        }

        l.update(idx, val);
        r.update(idx, val);
        combine();
    }

    public long getMaxSum(){
        return Math.max(selected[0][0],
               Math.max(selected[0][1], 
               Math.max(selected[1][0], selected[1][1])));
    }
}