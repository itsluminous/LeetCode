class Solution {
    public int trap(int[] height) {
        int n = height.length, water = 0;

        // find the maximum height on right side of an index
        var largestOnRight = new int[n];
        for(var i=n-2; i>=0; i--)
            largestOnRight[i] = Math.max(largestOnRight[i+1], height[i+1]);

        var largestOnLeft = height[0];
        for(var i=1; i<n; i++){
            // water level for any index will be equal to min of largest block on left or right
            var maxHeight = Math.min(largestOnLeft, largestOnRight[i]);
            largestOnLeft = Math.max(largestOnLeft, height[i]);

            // subtract height[i] from maxHeight to get actual water at that index
            if(maxHeight > height[i])
                water += maxHeight - height[i];
        }

        return water;
    }
}