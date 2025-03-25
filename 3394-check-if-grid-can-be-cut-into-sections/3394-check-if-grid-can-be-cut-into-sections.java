class Solution {
    public boolean checkValidCuts(int n, int[][] rectangles) {
        return canCut(rectangles, 0) || canCut(rectangles, 1);
    }

    private boolean canCut(int[][] rectangles, int idx){
        Arrays.sort(rectangles, (r1, r2) -> r1[idx] - r2[idx]);
        int cuts = 0, prevEnd = rectangles[0][idx+2];

        for(var rect : rectangles){
            int start = rect[idx], end = rect[idx+2];
            if(start >= prevEnd)
                if(++cuts == 2) return true;
            prevEnd = Math.max(prevEnd, end);
        }

        return false;
    }
}