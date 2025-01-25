public class Solution {
    public int[] LexicographicallySmallestArray(int[] nums, int limit) {
        var n = nums.Length;

        // tuples of num and its index
        var numIdx = new List<(int num, int idx)>();
        for(var i = 0; i < n; i++)
            numIdx.Add((nums[i], i));
        
        // sort numIdx asc based on num value
        numIdx = numIdx.OrderBy(x => x.num).ToList();

        // group numbers into different sets, based on their difference
        var sets = new List<List<(int num, int idx)>>();
        sets.Add([numIdx[0]]);
        for (var i = 1; i < n; i++) {
            if(numIdx[i].num - numIdx[i - 1].num > limit)
                sets.Add([numIdx[i]]);      // separate set
            else
                sets[^1].Add(numIdx[i]);    // part of prev set
        }
        
        foreach(var sett in sets){
            // sort indexes of all elements in curr set
            var indexes = sett.Select(x => x.idx).ToList();
            indexes.Sort();

            // now put smallest no. at smallest index, then next no. and so on
            for(var i = 0; i < indexes.Count; i++)
                nums[indexes[i]] = sett[i].num;
        }
        
        return nums;
    }
}