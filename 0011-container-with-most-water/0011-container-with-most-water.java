public class Solution {
    public int maxArea(int[] height) {
        int n = height.length, l = 0, r = n-1;
        var ans = 0;

        while(l < r){
            var curr = (r-l) * Math.min(height[r], height[l]);
            ans = Math.max(ans, curr);
            
            if(height[r] < height[l]) r--;
            else l++;
        }

        return ans;
    }
}