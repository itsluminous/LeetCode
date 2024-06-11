// this is plan
// 1. remove all duplicates (because we can't pick same num)
// 2. sort the array so that we can do binary search
// 3. we are guaranteed to have the biggest number in final ans, so ans = biggest + something
// 4. best value for "something" = biggest - 1, if it is present
// 5. if biggest - 1 is not present, then we need to try combination with all numbers smaller than this
class Solution {
    Map<Integer, Integer> dp = new HashMap<>();

    public int maxTotalReward(int[] rewardValues) {
        // we only care about unique numbers, because same num can never be picked again
        var sortedUniq = getSortedUnique(rewardValues);

        // we will definitely need the biggest number in answer
        var maxNum = sortedUniq.get(sortedUniq.size() - 1);
        var nextMaxNum = maxNum - 1;
        return maxNum + solve(sortedUniq, nextMaxNum);
    }

    private int solve(List<Integer> uniqNums, int limit){
        if(limit == 0) return 0;    // we cannot take any elements from uniqNums
        if(dp.containsKey(limit)) return dp.get(limit);   // already calculated this limit

        // find index of number <= limit
        var idx = binarySearch(uniqNums, limit);
        if(idx == -1) return limit;     // found exact match, this is best case

        // try all numbers before the idx and figure out best outcome
        var res = 0;
        for(var i=0; i<idx; i++){
            var maxNum = uniqNums.get(i);
            var nextMaxNum = Math.min(uniqNums.get(i) - 1, limit - maxNum);

            var curr = maxNum + solve(uniqNums, nextMaxNum);
            res = Math.max(res, curr);
        }

        dp.put(limit, res);
        return res;
    }

    // return -1 in case of exact match
    private int binarySearch(List<Integer> uniqNums, int limit){
        int left = 0, right = uniqNums.size() - 1;
        var res = -1;
        
        while(left <= right){
            var mid = left + (right - left) / 2;
            if(uniqNums.get(mid) == limit) return -1;

            if(uniqNums.get(mid) < limit) left = mid + 1;
            else {
                res = mid;
                right = mid - 1;
            }
        }

        return res;
    }

    private List<Integer> getSortedUnique(int[] rewardValues){
        var uniq = new HashSet<Integer>();
        for (var value : rewardValues) uniq.add(value);

        var lst = new ArrayList<>(uniq);
        Collections.sort(lst);
        return lst;
    }
}