// DP - we can be sure that max sum possible is 3999 (because 2000 + 1999)
class Solution {
    public int maxTotalReward(int[] rewardValues) {
        var MAX_VAL = 4000;
        Arrays.sort(rewardValues);
        var n = rewardValues.length;
        var dp = new boolean[MAX_VAL];
        dp[0] = dp[rewardValues[0]] = true;

        for(var i=1; i<n; i++){
            dp[rewardValues[i]] = true;     // reach directly, without picking anyone else
            for(var j=0; j<rewardValues[i]; j++){
                if(dp[j]) dp[j + rewardValues[i]] = true;       // reach with transition
            }
        }

        // find max val
        for(var i=MAX_VAL-1; i>0; i--)
            if(dp[i]) return i;
        return 0;
    }
}

// Accepted - brute force
class SolutionBF {
    public int maxTotalReward(int[] rewardValues) {
        Arrays.sort(rewardValues);
        int n = rewardValues.length, maxReward = 0;
        var nums = new HashSet<Integer>();
        nums.add(0);
        
        for(var reward : rewardValues){
            var temp = new HashSet<Integer>();
            for(var num : nums)
                if(num < reward){
                    temp.add(num + reward);
                    maxReward = Math.max(maxReward, num + reward);
                }
            nums.addAll(temp);
        }
        return maxReward;
    }
}