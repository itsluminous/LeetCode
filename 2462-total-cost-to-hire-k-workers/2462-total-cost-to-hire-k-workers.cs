public class Solution {
    public long TotalCost(int[] costs, int k, int candidates) {
        int leftIdx = 0, rightIdx = costs.Length-1;
        PriorityQueue<int, int> leftpq = new PriorityQueue<int, int>(), 
                                rightpq = new PriorityQueue<int, int>();

        long totalCost = 0;
        while(k-- > 0){
            // populate left pq
            while(leftpq.Count < candidates && leftIdx <= rightIdx)
                leftpq.Enqueue(costs[leftIdx], costs[leftIdx++]);
            
            // populate right pq
            while(rightpq.Count < candidates && leftIdx <= rightIdx)
                rightpq.Enqueue(costs[rightIdx], costs[rightIdx--]);

            // fetch min from left & right
            int leftMin = int.MaxValue, rightMin = int.MaxValue;
            if(leftpq.Count > 0) leftMin = leftpq.Peek();
            if(rightpq.Count > 0) rightMin = rightpq.Peek();

            // and smallest val to answer
            if(leftMin <= rightMin){
                totalCost += leftMin;
                leftpq.Dequeue();
            }
            else{
                totalCost += rightMin;
                rightpq.Dequeue();
            }
        }

        return totalCost;
    }
}