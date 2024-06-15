public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        var n = profits.Length;
        var profCap = new (int profit, int capital)[n];
        for(var i=0; i<n; i++)
            profCap[i] = (profits[i], capital[i]);

        // sort based on capital
        Array.Sort(profCap, (pc1, pc2) => pc1.capital - pc2.capital);

        // PQ stores profits of all projects with capital requirement <= cap;
        int cap = w, idx = 0;
        var pq = new PriorityQueue<int, int>();

        while(k != 0){
            while(idx < n && profCap[idx].capital <= cap)
                pq.Enqueue(profCap[idx].profit, -profCap[idx++].profit);
            if(pq.Count == 0) break;
            cap += pq.Dequeue();
            k--;
        }
        
        return cap;
    }
}