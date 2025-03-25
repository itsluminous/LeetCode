public class Solution {
    public bool CheckValidCuts(int n, int[][] rectangles) {
        return CanCut(rectangles, 0) || CanCut(rectangles, 1);
    }

    private bool CanCut(int[][] rectangles, int idx){
        Array.Sort(rectangles, (r1, r2) => r1[idx] - r2[idx]);
        int cuts = 0, prevEnd = rectangles[0][idx+2];

        foreach(var rect in rectangles){
            int start = rect[idx], end = rect[idx+2];
            if(start >= prevEnd)
                if(++cuts == 2) return true;
            prevEnd = Math.Max(prevEnd, end);
        }

        return false;
    }
}