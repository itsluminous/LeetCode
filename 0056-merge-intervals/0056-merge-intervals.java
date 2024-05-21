class Solution {
    public int[][] merge(int[][] intervals) {
        var ans = new ArrayList<int[]>();
        Arrays.sort(intervals, (i1, i2) -> i1[0] - i2[0]);
        ans.add(intervals[0]);
        
        for(var interval : intervals){
            var prev = ans.get(ans.size() - 1);
            if(interval[0] <= prev[1])
                prev[1] = Math.max(prev[1], interval[1]);
            else
                ans.add(interval);
        }

        return ans.toArray(new int[ans.size()][]);
    }
}