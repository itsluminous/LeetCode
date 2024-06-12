class Solution {
    int[] perm;
    boolean[] set;

    public String getPermutation(int n, int k) {
        initialize();
        return solve(n, k);
    }

    private String solve(int n, int k){
        if(n == 1){
            for(var i=1; i<10; i++)
                if(!set[i]) return Integer.toString(i);
        }

        // find out how many digits need to be skipped to get relevant count
        var count = perm[n-1];
        var curr = 1;
        while(curr * count < k) curr++;
        curr--;
        k -= curr * count;

        // find unused number in set, which is at position "count"
        var sb = new StringBuilder();
        var idx = 1;
        for(; idx<10; idx++){
            if(set[idx]) continue;
            if(curr-- == 0) break;
        }

        // mark the "idx" number as used, and look for number in next position
        set[idx] = true;
        sb.append(idx);
        sb.append(solve(n-1, k));
        return sb.toString();
    }

    private void initialize(){
        perm = new int[10];
        perm[1] = 1;
        for(var i=2; i<10; i++) perm[i] = i * perm[i-1];

        set = new boolean[10];
        set[0] = true;  // we cannot pick 0, so mark it as visited
    }
}