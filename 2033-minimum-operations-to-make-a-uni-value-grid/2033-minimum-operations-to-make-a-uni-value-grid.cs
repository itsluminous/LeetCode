public class Solution {
    public int MinOperations(int[][] grid, int x) {
        int m = grid.Length, n = grid[0].Length;
        var nums = new List<int>();

        // convert 2d array to 1d array
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                nums.Add(grid[i][j]);

        // find median using quick select. all numbers will be converted to this value
        var mid = (m*n)/2;
        var median = GetMedian(nums, mid+1);

        // try to convert every number to median
        var ops = 0;
        foreach(var num in nums){
            var diff = Math.Abs(num - median);
            if(diff % x != 0) return -1;    // can never be converted
            ops += (diff / x);
        }

        return ops;
    }

    // get median using quick select
    private int GetMedian(List<int> nums, int idx){
        // pick random pivot to avoid worse case complexity in quick sort
        var rand = new Random();
        var pivot = nums[rand.Next(nums.Count)];

        List<int> left = new(), right = new(), mid = new();
        foreach(var num in nums){
            if(num < pivot) left.Add(num);
            else if(num > pivot) right.Add(num);
            else mid.Add(num);
        }

        int l = left.Count, m = mid.Count, r=right.Count;
        if(l >= idx) return GetMedian(left, idx);
        if(l + m < idx) return GetMedian(right, idx-(l+m));
        return mid[0];  // all items in mid will have same value
    }

    private int GetMedianSort(List<int> nums, int idx){
        nums.Sort();
        return nums[idx-1];
    }
}