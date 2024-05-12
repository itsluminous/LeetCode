// rotating a permutation will not change it's score
// to make final array lexicographically smallest, we put 0 as first number
// then we start from end of array and try every number till n and see which one gives min cost
// i.e. we are finalizing last index first, then second last and so on....
public class Solution {
    Dictionary<(int, int), (int score, List<int> lst)>dp;

    public int[] FindPermutation(int[] nums) {
        // a bitmask represents which 
        // for each bitmask & prev val,  store the min score and the corresponding array
        dp = new Dictionary<(int, int), (int score, List<int> lst)>();
        GetMinCost(nums, 1, 0);    // prev num is 0 because I will always keep 0 as first number

        var ans = dp[(1,0)].lst;    
        ans.Insert(0, 0);           // 0 is first number in final ans
        return ans.ToArray();
    }

    private int GetMinCost(int[] nums, int mask, int prev){
        if(dp.ContainsKey((mask, prev))) return dp[(mask, prev)].score;

        var n = nums.Length;
        if(mask == (1<<n) - 1) return Math.Abs(prev - nums[0]);     // if mask indicates last num, prev has to be first num

        int minScore = int.MaxValue, minNum = -1;
        for(var i=0; i<n; i++){
            if((mask & (1 << i)) == 0){         // if not set yet
                var newMask = mask | (1 << i);  // set current pos
                var currScore = Math.Abs(prev - nums[i]) + GetMinCost(nums, newMask, i);
                if(currScore < minScore)
                    (minScore, minNum) = (currScore, i);
            }
        }

        var newList = new List<int>();
        var maskOfMinNum = mask | (1 << minNum);
        if(dp.ContainsKey((maskOfMinNum, minNum))) 
            newList = new List<int>(dp[(maskOfMinNum, minNum)].lst);    // clone the existing list
        newList.Insert(0, minNum);      // prepend current minNum to final ans
        dp[(mask, prev)] = (minScore, newList);
        return minScore;
    }
}