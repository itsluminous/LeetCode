class Solution {
    public int longestSubarray(int[] nums, int limit) {
        // min & max heap to store the actual number and its index
        var maxQ = new PriorityQueue<int[]>((n1, n2) -> n2[0] - n1[0]);
        var minQ = new PriorityQueue<int[]>((n1, n2) -> n1[0] - n2[0]);

        int longest = 1, idx = 0;
        for(var i=0; i<nums.length; i++){
            maxQ.offer(new int[]{nums[i], i});
            minQ.offer(new int[]{nums[i], i});

            // if the diff between min & max in curr window exceeds limit, then increment the left index
            while(maxQ.peek()[0] - minQ.peek()[0] > limit){
                idx = Math.min(maxQ.peek()[1], minQ.peek()[1]) + 1;         // new left idx
                while(!maxQ.isEmpty() && maxQ.peek()[1] < idx) maxQ.poll(); // remove invalid max
                while(!minQ.isEmpty() && minQ.peek()[1] < idx) minQ.poll(); // remove invalid min
            }

            longest = Math.max(longest, i - idx + 1);
        }

        return longest;
    }
}