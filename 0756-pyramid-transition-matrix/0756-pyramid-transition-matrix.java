class Solution {
    public boolean pyramidTransition(String bottom, List<String> allowed) {
        // build a map of allowed sets
        var map = new int[7][7];
        for(var al : allowed)
            map[al.charAt(0) - 'A'][al.charAt(1) - 'A'] |= 1 << (al.charAt(2) - 'A');
        
        // convert bottom row to int for ease of operations
        var n = bottom.length();
        var row = new int[n];
        for(var i=0; i<n; i++) row[i] = bottom.charAt(i) - 'A';

        // try all permutations now
        return solve(map, row, 0, n);
    }

    private boolean solve(int[][] map, int[] row, int start, int end){
        // only one cell left in row, no more rows need to be built
        if(end == 1) return true;

        // if start has reached end, then build new row
        if(start == end-1) return solve(map, row, 0, end-1);

        // get all possible blocks that can be placed on top of row[start] and row[start+1]
        var val = map[row[start]][row[start + 1]];
        if(val == 0) return false; // no valid block can be placed

        // try each possible block
        var orig = row[start];
        for(int num = 0, mask = 1; num < 7; num++, mask <<= 1){
            if((mask & val) == 0) continue; // this block is not allowed
            
            row[start] = num; // place this block
            if(solve(map, row, start + 1, end)) return true; // found solution
        }
        
        row[start] = orig;  // backtrack
        return false;       // no valid solution found
    }
}