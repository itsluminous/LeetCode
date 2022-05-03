// Accepted - using stack - O(n)
public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int n = nums.Length, start = n, end = 0;
        var stack = new Stack<int>();
        
        // find start index of unsorted array
        for(var i=0; i<n; i++){
            // if curr number is greater than the one on top, keep popping till we find appropriate place
            while(stack.Count > 0 && nums[stack.Peek()] > nums[i])
                start = Math.Min(start, stack.Pop());
            stack.Push(i);
        }
        
        stack.Clear();
        
        // find end index of unsorted array
        for(var i=n-1; i>=0; i--){
            // if curr number is smaller than the one on top, keep popping till we find appropriate place
            while(stack.Count > 0 && nums[stack.Peek()] < nums[i])
                end = Math.Max(end, stack.Pop());
            stack.Push(i);
        }
        
        // return length of subarray to be sorted
        return end-start > 0 ? end-start+1 : 0;
    }
}

// Accepted - O(n log n)
public class Solution1 {
    public int FindUnsortedSubarray(int[] nums) {
        int n = nums.Length, start = -1, end = -1;
        
        // clone the array and then sort it
        var sorted = (int[]) nums.Clone();
        Array.Sort(sorted);
        
        // compare sorted array with original to find start and end index of different numbers
        for(var i=0; i<n; i++){
            if(nums[i] != sorted[i]){
                start = i;
                break;
            }
        }
        
        for(var i=n-1; i>0; i--){
            if(nums[i] != sorted[i]){
                end = i+1;
                break;
            }
        }
        
        // return length of subarray to be sorted
        return end-start;
    }
}