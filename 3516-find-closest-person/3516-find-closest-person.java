class Solution {
    public int findClosest(int x, int y, int z) {
        var dx = Math.abs(z-x);
        var dy = Math.abs(z-y);

        if(dx == dy) return 0;
        else if(dx < dy) return 1;
        else return 2;
    }
}