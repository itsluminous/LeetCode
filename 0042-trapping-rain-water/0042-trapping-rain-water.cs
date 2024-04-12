// water level for any index will be equal to smaller one of largest block on left and right
// now, subtract height[i] from that to get actual water at that index
public class Solution {
    public int Trap(int[] height) {
        var n = height.Length;

        // find the maximum height on either side of an index
        int[] lmax = new int[n], rmax = new int[n];
        for(int i=1, j=n-2; i<n; i++, j--){
            lmax[i] = Math.Max(lmax[i-1], height[i-1]);
            rmax[j] = Math.Max(rmax[j+1], height[j+1]);
        }

        // now calculated water at an index, using intution
        var trapped = 0;
        for(var i=1; i<n-1; i++){
            var water = Math.Min(lmax[i], rmax[i]);
            var curr = (water - height[i]) > 0 ? (water - height[i]) : 0;
            trapped += curr;
        }

        return trapped;
    }
}