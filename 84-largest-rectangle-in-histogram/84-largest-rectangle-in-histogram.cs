// Explaination here : https://leetcode.com/problems/largest-rectangle-in-histogram/discuss/28902/5ms-O(n)-Java-solution-explained-(beats-96)
// Idea is that we always have height for each bar, all we need is figure out the width based on how many bar can accomodate this height
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var n = heights.Length;
        int[] leftLessIndex = new int[n], rightLessIndex = new int[n];
        leftLessIndex[0] = -1;
        rightLessIndex[n-1] = n;
        
        // for each bar, find the point on left where we get lesser sized bar
        for(var i=1; i<n; i++){
            var curr = i-1;
            while(curr >= 0 && heights[curr] >= heights[i])
                curr = leftLessIndex[curr];
            leftLessIndex[i] = curr;
        }
        
        // for each bar, find the point on right where we get lesser sized bar
        for(var i=n-2; i>=0; i--){
            var curr = i+1;
            while(curr < n && heights[curr] >= heights[i])
                curr = rightLessIndex[curr];
            rightLessIndex[i] = curr;
        }
        
        // now using this data, find max rectangle
        var max = 0;
        for(var i=0; i<n; i++){
            var area = heights[i] * (rightLessIndex[i] - leftLessIndex[i] - 1);
            max = Math.Max(max, area);
        }
        
        return max;
    }
}