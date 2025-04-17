// Brute Force
public class Solution {
    public int CountPairs(int[] nums, int k) {
        var count = 0;
        for(var i=0; i < nums.Length; i++)
            for(var j=i+1; j < nums.Length; j++)
                if(nums[i] == nums[j] && i*j % k == 0)
                    count++;

        return count;
    }
}

// Accepted - first group same numbers together, then check divisibility
public class SolutionMap {
    public int CountPairs(int[] nums, int k) {
        var sameIdx = new List<int>[101];
        for(var i=0; i<101; i++) sameIdx[i] = new();

        for(var i=0; i<nums.Length; i++)
            sameIdx[nums[i]].Add(i);

        var count = 0;
        foreach(var indexes in sameIdx){
            if(indexes.Count < 2) continue;
            for(var i=0; i<indexes.Count; i++)
                for(var j=i+1; j<indexes.Count; j++)
                    if((indexes[i] * indexes[j]) % k == 0)
                        count++;
        }

        return count;
    }
}