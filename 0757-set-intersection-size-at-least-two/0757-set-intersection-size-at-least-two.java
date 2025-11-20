class Solution {
    public int intersectionSizeTwo(int[][] intervals) {
        Arrays.sort(intervals, (a, b) -> 
            a[1] == b[1] ? b[0] - a[0] : a[1] - b[1]
        );

        var ans = 0;
        int start = -1, end = -1;
        int prevStart = -1, prevEnd = -1;

        for(var it : intervals){
            start = it[0];
            end = it[1];

            if(start > prevEnd){
                // new pair
                prevStart = end-1;
                prevEnd = end;
                ans += 2;
            }
            else if(start > prevStart) {
                // one reuse
                prevStart = prevEnd;
                prevEnd = end;
                ans += 1;
            }
        }

        return ans;
    }
}