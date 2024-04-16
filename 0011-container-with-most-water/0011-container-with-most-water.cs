public class Solution {
    public int MaxArea(int[] height) {
        int n = height.Length, l = 0, r = n-1;
        var ans = 0;

        while(l < r){
            var curr = (r-l) * Math.Min(height[r], height[l]);
            ans = Math.Max(ans, curr);
            
            if(height[r] < height[l]) r--;
            else l++;
        }

        return ans;
    }
}