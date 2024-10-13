class Solution {
    public int[] smallestRange(List<List<Integer>> nums) {
        // create a minHeap to be able to get smallest element out of all lists
        var minHeap = new PriorityQueue<int[]>((p1, p2) -> p1[0] - p2[0]);   // the array will be [num, row, col]
        int start = -1, end = nums.get(0).get(0), range = Integer.MAX_VALUE;

        // add first element from all lists to minHeap
        for(var r=0; r<nums.size(); r++){
            end = Math.max(end, nums.get(r).get(0));
            minHeap.offer(new int[] {nums.get(r).get(0), r, 0});
        }

        // loop until we have exhausted atleast one row in nums
        while(minHeap.size() == nums.size()){
            var val = minHeap.poll();
            int num = val[0], r = val[1], c = val[2];
            
            // we found a smaller range
            if(end - num < range){
                start = num;
                range = end - start;
            }

            // if we exhausted all values in a row, then we need to stop
            if(c+1 == nums.get(r).size()) break;
            
            // else add the next element from that row to minHeap
            minHeap.offer(new int[] {nums.get(r).get(c+1), r, c+1});
            end = Math.max(end, nums.get(r).get(c+1));
        }

        return new int[]{start, start+range};
    }
}