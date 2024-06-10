class Solution {
    public int heightChecker(int[] heights) {
        var n = heights.length;

        // count how many students have given height
        var freq = new int[101];
        for(var h : heights) freq[h]++;

        // now find misplaced ones
        int pos = 0, misplaced = 0, processed = 0;
        for(var h = 1; h <= 100 && processed < n; h++){
            var maxPos = pos + freq[h];
            processed += freq[h];
            for(var i = pos; i < maxPos; i++)
                if(heights[i] != h) misplaced++;
            pos = maxPos;
        }

        return misplaced;
    }
}