// DP - we can be sure that max sum possible is 3999 (because 2000 + 1999)
class Solution {
    public int MaxTotalReward(int[] rewardValues) {
        var MAX_VAL = 4000;
        Array.Sort(rewardValues);
        var n = rewardValues.Length;
        var dp = new bool[MAX_VAL];
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
    public int MaxTotalReward(int[] rewardValues) {
        Array.Sort(rewardValues);
        int n = rewardValues.Length, maxReward = 0;
        var nums = new HashSet<int>();
        nums.Add(0);
        
        foreach(var reward in rewardValues){
            var temp = new HashSet<int>();
            foreach(var num in nums)
                if(num < reward){
                    temp.Add(num + reward);
                    maxReward = Math.Max(maxReward, num + reward);
                }
            nums.UnionWith(temp);
        }
        return maxReward;
    }
}