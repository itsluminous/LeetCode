public class Solution {
    public int MaxDistance(string s, int k) {
        var count = new int[100];
        var maxdist = 0;
        for(var i=0; i<s.Length; i++){
            count[s[i]]++;
            var oppositeDirs = Math.Min(count['N'], count['S']) + Math.Min(count['E'], count['W']);
            // no. of dir changes = (i+1), and we can at most revert oppositeDirs moves in this
            // each dir removal have double impact on manhattan distance, hence * 2
            var dist = i + 1 - (2 * oppositeDirs);
            // reverting oppositeDirs moves will also add same moves on opposite direction
            // hence multiply by 2
            // but we can only revert max of k moves
            dist += 2 * Math.Min(k, oppositeDirs);
            maxdist = Math.Max(maxdist, dist);
        }
        
        return maxdist;
    }
}