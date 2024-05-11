class Solution {
    public double mincostToHireWorkers(int[] quality, int[] wage, int k) {
        var n = wage.length;

        // find wage to quality ratio of each worker
        var ratioQuality = new double[n][2];
        for(var i=0; i<n; i++){
            var wqratio = (double)wage[i]/quality[i];
            ratioQuality[i] = new double[]{wqratio, (double)quality[i]};
        }

        // sort by ratio ascending
        Arrays.sort(ratioQuality, (rq1, rq2) -> Double.compare(rq1[0], rq2[0]));

        double ans = Double.MAX_VALUE, totalQuality = 0;
        var pq = new PriorityQueue<Double>();     // pq to sort desc based on quality

        // try to find smallest sum of k worker's quality, and multiply with ratio to get ans
        for(var rq : ratioQuality){
            totalQuality += rq[1];
            pq.offer(-rq[1]);      // we want to sort desc, so negative priority

            // remove worker with highest quality (so that totalQuality remains smaller)
            if(pq.size() > k) totalQuality += pq.poll();

            // if count is k, then multiply totalQuality with current worker's ratio to get cost
            // why current worker's cost? because all workers before him had lower ratio, so lower wage expectations
            // so they will be happy with the money they get based on this
            if(pq.size() == k) ans = Math.min(ans, rq[0] * totalQuality);
        }

        return ans;
    }
}