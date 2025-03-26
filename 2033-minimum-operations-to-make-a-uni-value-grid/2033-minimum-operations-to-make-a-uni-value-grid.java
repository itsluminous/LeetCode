class Solution {
    public int minOperations(int[][] grid, int x) {
        int m = grid.length, n = grid[0].length;
        var nums = new ArrayList<Integer>();

        // convert 2d array to 1d array
        for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                nums.add(grid[i][j]);

        // find median using quick select. all numbers will be converted to this value
        var mid = (m*n)/2;
        var median = getMedianQS(nums, mid+1);

        // try to convert every number to median
        var ops = 0;
        for(var num : nums){
            var diff = Math.abs(num - median);
            if(diff % x != 0) return -1;    // can never be converted
            ops += (diff / x);
        }

        return ops;
    }

    // get median using quick select
    private int getMedianQS(List<Integer> nums, int idx){
        // pick random pivot to avoid worse case complexity in quick sort
        var rand = new Random();
        var pivot = nums.get(rand.nextInt(nums.size()));

        List<Integer> left = new ArrayList<>(), right = new ArrayList<>(), mid = new ArrayList<>();
        for(var num : nums){
            if(num < pivot) left.add(num);
            else if(num > pivot) right.add(num);
            else mid.add(num);
        }

        int l = left.size(), m = mid.size(), r=right.size();
        if(l >= idx) return getMedianQS(left, idx);
        if(l + m < idx) return getMedianQS(right, idx-(l+m));
        return mid.get(0);  // all items in mid will have same value
    }

    // to find median by sorting array - slower
    private int getMedianSort(List<Integer> nums, int idx){
        nums.sort(null);
        return nums.get(idx-1);
    }
}