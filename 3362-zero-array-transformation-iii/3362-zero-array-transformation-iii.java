// idea is to pick queries with longest range, as they will help in reducing more indexes
class Solution {
    public int maxRemoval(int[] nums, int[][] queries) {
        int nLen = nums.length, qLen = queries.length;
        Arrays.sort(queries, (q1, q2) -> q1[0] - q2[0]);    // sort queries by starting idx
        var pq = new PriorityQueue<Integer>(Collections.reverseOrder());    // maxHeap to get longest end index first
        var delta = new int[nLen + 1];   // at what index we can decrement, and how much

        var decr = 0;   // how many decrements can we do at this point
        for(int i=0, q=0; i<nLen; i++){
            decr += delta[i];
            
            // put all queries starting at curr index in heap
            while(q < qLen && queries[q][0] == i)
                pq.offer(queries[q++][1]);
            
            // use queries in heap till the curr index can be made 0
            while(decr < nums[i] && !pq.isEmpty() && pq.peek() >= i){
                decr++;
                delta[pq.poll() + 1]--;
            }

            // check if nums[i] can be made 0
            if(decr < nums[i]) return -1;
        }

        return pq.size();   // all leftovers in heap can be removed
    }
}