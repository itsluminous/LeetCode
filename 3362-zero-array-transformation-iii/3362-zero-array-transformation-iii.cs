// idea is to pick queries with longest range, as they will help in reducing more indexes
public class Solution {
    public int MaxRemoval(int[] nums, int[][] queries) {
        int nLen = nums.Length, qLen = queries.Length;
        Array.Sort(queries, (q1, q2) => q1[0] - q2[0]);    // sort queries by starting idx
        var pq = new PriorityQueue<int, int>();     // maxHeap to get longest end index first
        var delta = new int[nLen + 1];   // at what index we can decrement, and how much

        var decr = 0;   // how many decrements can we do at this point
        for(int i=0, q=0; i<nLen; i++){
            decr += delta[i];
            
            // put all queries starting at curr index in heap
            while(q < qLen && queries[q][0] == i)
                pq.Enqueue(queries[q][1], -queries[q++][1]);
            
            // use queries in heap till the curr index can be made 0
            while(decr < nums[i] && pq.Count > 0 && pq.Peek() >= i){
                decr++;
                delta[pq.Dequeue() + 1]--;
            }

            // check if nums[i] can be made 0
            if(decr < nums[i]) return -1;
        }

        return pq.Count;   // all leftovers in heap can be removed
    }
}