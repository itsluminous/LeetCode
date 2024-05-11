public class Solution {
    public double MincostToHireWorkers(int[] quality, int[] wage, int k) {
        var n = wage.Length;

        // find wage to quality ratio of each worker
        var ratioQuality = new (double ratio, int quality)[n];
        for(var i=0; i<n; i++){
            var wqratio = (double)wage[i]/quality[i];
            ratioQuality[i] = (wqratio, quality[i]);
        }

        // sort by ratio ascending
        Array.Sort(ratioQuality, (rq1, rq2) => rq1.ratio.CompareTo(rq2.ratio));

        double ans = double.MaxValue;
        var totalQuality = 0;
        var pq = new PriorityQueue<int, int>();     // pq to sort desc based on quality

        // try to find smallest sum of k worker's quality, and multiply with ratio to get ans
        foreach(var (ratio, qwality) in ratioQuality){
            totalQuality += qwality;
            pq.Enqueue(qwality, -qwality);      // we want to sort desc, so negative priority

            // remove worker with highest quality (so that totalQuality remains smaller)
            if(pq.Count > k) totalQuality -= pq.Dequeue();

            // if count is k, then multiply totalQuality with current worker's ratio to get cost
            // why current worker's cost? because all workers before him had lower ratio, so lower wage expectations
            // so they will be happy with the money they get based on this
            if(pq.Count == k) ans = Math.Min(ans, ratio * totalQuality);
        }

        return ans;
    }
}

/*
Why do we choose the highest quality person to remove? Why not choosing other workers?

Since the workers are sorted in the increasing order of the wage/quality ratio, the global ratio will never decrease while iterating. For the previously scanned wrokers, we do not care about their personal ratios any more because their personal ratios will always be <= the current global ratio. So the previous workers' personal ratio will never affect the total payment.
Similarly, their personal base payment (i.e. the wage input) has been satisfied already. As the global ratio increases, their actual payemnt will only increase or stay the same, and will never become lower than their base payment.
So when deciding whom to remove, the only thing that matters is the workers' quality. With a given global ratio, removing the highest quality worker will reduces the total payment as much as possible. That is why we want to removing the highest quality worker.
*/