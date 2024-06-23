public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        // min & max heap to store the actual number and its index
        PriorityQueue<int[], int> maxQ = new(), minQ = new();

        int longest = 1, idx = 0;
        for(var i=0; i<nums.Length; i++){
            maxQ.Enqueue(new int[]{nums[i], i}, -nums[i]);
            minQ.Enqueue(new int[]{nums[i], i}, nums[i]);

            // if the diff between min & max in curr window exceeds limit, then increment the left index
            while(maxQ.Peek()[0] - minQ.Peek()[0] > limit){
                idx = Math.Min(maxQ.Peek()[1], minQ.Peek()[1]) + 1;           // new left idx
                while(maxQ.Count > 0 && maxQ.Peek()[1] < idx) maxQ.Dequeue(); // remove invalid max
                while(minQ.Count > 0 && minQ.Peek()[1] < idx) minQ.Dequeue(); // remove invalid min
            }
            longest = Math.Max(longest, i - idx + 1);
        }

        return longest;
    }
}