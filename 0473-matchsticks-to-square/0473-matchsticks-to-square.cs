// using backtracking with DP
public class Solution {
    int visited = 0;
    HashSet<int>[] seen;  // track if this bitmask has been seen or not (for given k)

    public bool Makesquare(int[] matchsticks) {
        var k = 4;  // need to divide the matchsticks into k equal groups
        if(matchsticks.Length < k) return false;

        var totalSum = matchsticks.Sum();
        if(totalSum % k != 0) return false;  // it can never be divided in 4

        // sort array in descending
        Array.Sort(matchsticks);
        Array.Reverse(matchsticks);

        var sideSum = totalSum / k;              // allowed sum of each side
        if(matchsticks[0] > sideSum) return false;  // one stick cannot exceed sideSum

        // try to split the matchsticks into k groups
        seen = new HashSet<int>[matchsticks.Length+1];
        for(var i=0; i<=matchsticks.Length; i++) seen[i] = new HashSet<int>();
        return Makesquare(matchsticks, k, sideSum, 0, 0);
    }

    private bool Makesquare(int[] matchsticks, int k, int targetSum, int currSum, int idx){
        // if we have already seen this mask, then useless
        if(seen[k].Contains(visited)) return false;
        seen[k].Add(visited);

        // all pending matchsticks can be put in one side, if we need only one side
        if(k == 1) return true; 
        
        // if current side is done, then look for other sides
        if(currSum == targetSum) return Makesquare(matchsticks, k-1, targetSum, 0, 0);

        // try to fit every remaining matchstick one by one to match targetSum
        for(var i=idx; i<matchsticks.Length; i++){
            var mask = 1 << i;
            if((visited & mask) == mask || (currSum + matchsticks[i]) > targetSum) continue;
            visited |= mask;
            if(Makesquare(matchsticks, k, targetSum, currSum + matchsticks[i], idx+1)) return true;
            visited ^= mask;
        }

        // not possible to make square with current setup
        return false;
    }
}