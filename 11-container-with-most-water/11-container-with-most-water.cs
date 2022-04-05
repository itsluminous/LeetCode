public class Solution {
    public int MaxArea(int[] height) {
        int l=0, r=height.Length-1, maxWater = 0;
        while(l < r){
            var currWater = (r-l) * Math.Min(height[r], height[l]);
            maxWater = Math.Max(maxWater, currWater);
            if(height[r] < height[l])
                r--;
            else
                l++;
        }
        
        return maxWater;
    }
}