public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        bool xOverlap = false, yOverlap = false;
        if(rec2[0] > rec1[0] && rec2[0] < rec1[2]) xOverlap = true;
        if(rec2[2] > rec1[0] && rec2[2] < rec1[2]) xOverlap = true;
        if(rec1[0] > rec2[0] && rec1[0] < rec2[2]) xOverlap = true;
        if(rec1[2] > rec2[0] && rec1[2] < rec2[2]) xOverlap = true;

        if(rec2[1] > rec1[1] && rec2[1] < rec1[3]) yOverlap = true;
        if(rec2[3] > rec1[1] && rec2[3] < rec1[3]) yOverlap = true;
        if(rec1[1] > rec2[1] && rec1[1] < rec2[3]) yOverlap = true;
        if(rec1[3] > rec2[1] && rec1[3] < rec2[3]) yOverlap = true;

        return xOverlap && yOverlap;
    }
}