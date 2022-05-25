public class Solution {
    public int MaxEnvelopes(int[][] envelopes)
    {
        // Ascend on width and descend on height if width are same.
        Array.Sort(envelopes, (a, b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0]));

        // Longest increasing subsequence
        var dp = new int[envelopes.Length];
        var len = 0;
        foreach(var env in envelopes){
            // find position of current envelope based on height
            var index = Array.BinarySearch(dp, 0, len, env[1]);
            if(index< 0) index = ~index;
            dp[index] = env[1];
            if(index == len) len++;     // LIS algo
        }
        return len;
    }
}

// does not work - because we can't pick the first available envelope blindly, if we skip it, we may get better next envelope
public class Solution1 {
    public int MaxEnvelopes(int[][] envelopes) {
        var env = envelopes.OrderBy(e => e[0]).ThenBy(e => e[0]+e[1]).ToArray();
        var count = 1;
        var prev = env[0];
        for(var i=1; i<env.Length; i++){
            var curr = env[i];
            if(curr[0] > prev[0] && curr[1] > prev[1]){
                prev = curr;
                count++;
            }
        }
        
        return count;
    }
}