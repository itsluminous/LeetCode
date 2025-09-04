public class Solution {
    public int FindClosest(int x, int y, int z) {
        var dx = Math.Abs(z-x);
        var dy = Math.Abs(z-y);

        if(dx == dy) return 0;
        else if(dx < dy) return 1;
        else return 2;
    }
}