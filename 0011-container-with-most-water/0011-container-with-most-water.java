class Solution {
    public int maxArea(int[] height) {
        int left = 0, right = height.length - 1;
        var maxWater = 0;

        while(left < right){
            var currHeight = Math.min(height[left], height[right]);
            var currWidth = right - left;
            maxWater = Math.max(maxWater, currHeight * currWidth);

            if(height[left] < height[right]) left++;
            else right--;
        }

        return maxWater;
    }
}