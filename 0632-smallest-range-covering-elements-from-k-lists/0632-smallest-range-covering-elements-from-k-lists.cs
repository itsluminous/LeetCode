public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        // create a minHeap to be able to get smallest element out of all lists
        var minHeap = new PriorityQueue<int[], int>();   // the array will be [num, row, col]
        int start = -1, end = nums[0][0], range = int.MaxValue;

        // add first element from all lists to minHeap
        for(var r=0; r<nums.Count; r++){
            end = Math.Max(end, nums[r][0]);
            minHeap.Enqueue([nums[r][0], r, 0], nums[r][0]);
        }

        // loop until we have exhausted atleast one row in nums
        while(minHeap.Count == nums.Count){
            var val = minHeap.Dequeue();
            var (num, r, c) = (val[0], val[1], val[2]);
            
            // we found a smaller range
            if(end - num < range){
                start = num;
                range = end - start;
            }

            // if we exhausted all values in a row, then we need to stop
            if(c+1 == nums[r].Count) break;
            
            // else add the next element from that row to minHeap
            minHeap.Enqueue([nums[r][c+1], r, c+1], nums[r][c+1]);
            end = Math.Max(end, nums[r][c+1]);
        }

        return [start, start+range];
    }
}