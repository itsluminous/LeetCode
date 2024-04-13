// basic idea is that largest rectangle will include atleast one bar in full
// so for each bar, find left and right limit for height >= that bar
// and thus we will know max area
// explaination : https://www.youtube.com/watch?v=vcv3REtIvEo
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var n = heights.Length;
        var stack = new Stack<int>();   // monotonic stack (increasing)
        int[] left = new int[n], right = new int[n];  // to keep track of first bar smaller than curr

        // for each bar, find the index of first bar smaller than itself on left
        for(var i=0; i<n; i++){
            while(stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();

            if(stack.Count == 0) left[i] = 0;
            else left[i] = stack.Peek() + 1;
            
            stack.Push(i);
        }

        // for each bar, find the index of first bar smaller than itself on right
        stack = new Stack<int>();
        for(var i=n-1; i>=0; i--){
            while(stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                stack.Pop();

            if(stack.Count == 0) right[i] = n-1;
            else right[i] = stack.Peek() - 1;
            
            stack.Push(i);
        }

        // for each index, find max area based on left & right array
        var max = 0;
        for(var i=0; i<n; i++){
            var curr = heights[i] * (right[i] - left[i] + 1);
            max = Math.Max(max, curr);
        }

        return max;
    }
}

// Accepted - without using extra stack space
// Explaination here : https://leetcode.com/problems/largest-rectangle-in-histogram/discuss/28902/5ms-O(n)-Java-solution-explained-(beats-96)
// Idea is that we always have height for each bar, all we need is figure out the width based on how many bar can accomodate this height
public class SolutionBetter {
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