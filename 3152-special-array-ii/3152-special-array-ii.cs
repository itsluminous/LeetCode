public class Solution {
    public bool[] IsArraySpecial(int[] nums, int[][] queries) {
        var n = queries.Length;
        var ans = new bool[n];

        // find starting index of all pairs who are bad
        var badIndex = new List<int>();
        for(var i=0; i<nums.Length-1; i++){
            if((nums[i] & 1) == 1 && (nums[i+1] & 1) == 1)  badIndex.Add(i);
            else if((nums[i] & 1) == 0 && (nums[i+1] & 1) == 0) badIndex.Add(i);
        }
        var bad = badIndex.ToArray();

        // now for each query, binary search on the bad array to see if any bad pair exists in range
        for(var i=0; i<n; i++){
            var (start, end) = (queries[i][0], queries[i][1]);

            var bi = Array.BinarySearch(bad, start);
            if(bi < 0) bi = ~bi;

            if(bi >= bad.Length || bad[bi] >= end) ans[i] = true;
        }

        return ans;
    }
}