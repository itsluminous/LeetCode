// using backtracking with DP
class Solution {
    int visited = 0;
    HashSet<Integer>[] seen;  // track if this bitmask has been seen or not (for given k)

    public boolean makesquare(int[] matchsticks) {
        var k = 4;  // need to divide the matchsticks into k equal groups
        if(matchsticks.length < k) return false;

        var totalSum = 0;
        for(var ms : matchsticks) totalSum += ms;
        if(totalSum % k != 0) return false;  // it can never be divided in 4

        // sort array in descending
        matchsticks = Arrays.stream(matchsticks)
                            .sorted()
                            .boxed()
                            .sorted((a, b) -> Integer.compare(b, a))
                            .mapToInt(Integer::intValue)
                            .toArray();

        var sideSum = totalSum / k;              // allowed sum of each side
        if(matchsticks[0] > sideSum) return false;  // one stick cannot exceed sideSum

        // try to split the matchsticks into k groups
        seen = new HashSet[matchsticks.length+1];
        for(var i=0; i<=matchsticks.length; i++) seen[i] = new HashSet<>();
        return makesquare(matchsticks, k, sideSum, 0, 0);
    }

    private boolean makesquare(int[] matchsticks, int k, int targetSum, int currSum, int idx){
        // if we have already seen this mask, then useless
        if(seen[k].contains(visited)) return false;
        seen[k].add(visited);

        // all pending matchsticks can be put in one side, if we need only one side
        if(k == 1) return true; 
        
        // if current side is done, then look for other sides
        if(currSum == targetSum) return makesquare(matchsticks, k-1, targetSum, 0, 0);

        // try to fit every remaining matchstick one by one to match targetSum
        for(var i=idx; i<matchsticks.length; i++){
            var mask = 1 << i;
            if((visited & mask) == mask || (currSum + matchsticks[i]) > targetSum) continue;
            visited |= mask;
            if(makesquare(matchsticks, k, targetSum, currSum + matchsticks[i], idx+1)) return true;
            visited ^= mask;
        }

        // not possible to make square with current setup
        return false;
    }
}