public class Solution {
    public int MaxPerformance(int n, int[] speed, int[] efficiency, int k) {
        var engineers = new Engineer[n];
        for(var i=0; i<n; i++)
            engineers[i] = new Engineer(speed[i], efficiency[i]);
        engineers = engineers.OrderByDescending(e => e.efficiency).ToArray();   // we want engineers with best efficiency
        
        long speedSum = 0, maxPerf = 0;
        var MOD = 1_000_000_007;
        var pq = new PriorityQueue<int,int>();
        foreach(var eng in engineers){
            if(pq.Count > k-1)  speedSum -= pq.Dequeue();   // to add a new engineer to list, we need to remove one added first
            pq.Enqueue(eng.speed, eng.speed);
            speedSum += eng.speed;
            maxPerf = Math.Max(maxPerf, speedSum * eng.efficiency);
        }
        
        return (int)(maxPerf % MOD);
    }
    
    // create new class to make readibility easier (else we could have used a 2D array)
    public class Engineer
    {
        public int speed;
        public int efficiency;
        public Engineer(int speed, int efficiency)
        {
            this.speed = speed;
            this.efficiency = efficiency;
        }
            
    }
}