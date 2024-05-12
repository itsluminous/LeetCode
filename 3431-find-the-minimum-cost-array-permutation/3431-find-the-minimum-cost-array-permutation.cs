// rotating a permutation will not change it's score
// to make final array lexicographically smallest, we put 0 as first number
public class Solution {
    Dictionary<(int, int), (int score, List<int> lst)>dp;

    public int[] FindPermutation(int[] nums) {
        // for each bitmask & prev val,  store the min score and the corresponding array
        dp = new Dictionary<(int, int), (int score, List<int> lst)>();
        GetMinScore(nums, 1, 0);    // prev num is 0 because I will always keep 0 as first number

        var ans = dp[(1,0)].lst;    
        ans.Insert(0, 0);           // 0 is my first number
        return ans.ToArray();
    }

    private int GetMinScore(int[] nums, int mask, int prev){
        if(dp.ContainsKey((mask, prev))) return dp[(mask, prev)].score;

        var n = nums.Length;
        if(mask == (1<<n) - 1) return Math.Abs(prev - nums[0]);     // if mask indicates last num, prev has to be first num

        int minScore = int.MaxValue, minNum = -1;
        for(var i=0; i<n; i++){
            if((mask & (1 << i)) == 0){         // if not set yet
                var newMask = mask | (1 << i);  // set current pos
                var currScore = Math.Abs(prev - nums[i]) + GetMinScore(nums, newMask, i);
                if(currScore < minScore)
                    (minScore, minNum) = (currScore, i);
            }
        }

        var newList = new List<int>();
        if(dp.ContainsKey((mask | (1 << minNum), minNum))) 
            newList = new List<int>(dp[(mask | (1 << minNum), minNum)].lst);
        newList.Insert(0, minNum);
        dp[(mask, prev)] = (minScore, newList);
        return minScore;
    }
}