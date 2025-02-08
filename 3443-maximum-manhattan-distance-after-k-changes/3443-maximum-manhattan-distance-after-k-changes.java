class Solution {
    public int maxDistance(String s, int k) {
        var count = new int[100];
        var maxdist = 0;
        for(var i=0; i<s.length(); i++){
            count[s.charAt(i)]++;
            var oppositeDirs = Math. min(count['N'], count['S']) + Math.min(count['E'], count['W']);
            // no. of dir changes = (i+1), and we can at most revert oppositeDirs moves in this
            // each dir removal have double impact on manhattan distance, hence * 2
            var dist = i + 1 - (2 * oppositeDirs);
            // reverting oppositeDirs moves will also add same moves on opposite direction
            // hence multiply by 2
            // but we can only revert max of k moves
            dist += 2 * Math.min(k, oppositeDirs);
            maxdist = Math.max(maxdist, dist);
        }
        
        return maxdist;
    }
}