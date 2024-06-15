class Solution {
    public int findMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        var n = profits.length;
        var profCap = new int[n][2];
        for(var i=0; i<n; i++){
            profCap[i][0] = profits[i];
            profCap[i][1] = capital[i];
        }

        // sort based on capital
        Arrays.sort(profCap, (pc1, pc2) -> pc1[1]-pc2[1]);

        // PQ stores profits of all projects with capital requirement <= cap;
        int cap = w, idx = 0;
        var pq = new PriorityQueue<Integer>();
        

        while(k != 0){
            while(idx < n && profCap[idx][1] <= cap)
                pq.offer(-profCap[idx++][0]);
            if(pq.isEmpty()) break;
            cap -= pq.poll();
            k--;
        }
        
        return cap;
    }
}