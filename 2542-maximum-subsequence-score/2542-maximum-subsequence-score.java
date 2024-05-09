class Solution {
    public long maxScore(int[] nums1, int[] nums2, int k) {
        var n = nums1.length;
        
        // merge nums1 & nums2 based on index
        var combined = new Pair[n];
        for(var i=0; i<n; i++) combined[i] = new Pair(nums1[i], nums2[i]);

        // sort this combined array by nums2 value, descending
        // When we iterate over this sorted array, we know that smallest n2 is curr index
        Arrays.sort(combined, (c1, c2) -> c2.n2 - c1.n2);

        // priority queue to track smallest in nums1, so that it can be removed if needed
        var pq = new PriorityQueue<Integer>();
        long ans = 0, num1Sum = 0;
        for(var cmb : combined){
            num1Sum += cmb.n1;

            pq.offer(cmb.n1);
            if(pq.size() > k) num1Sum -= pq.poll();   // remove smallest num1
            if(pq.size() == k) ans = Math.max(ans, num1Sum * cmb.n2);
        }

        return ans;
    }
}

class Pair {
    int n1;
    int n2;

    Pair(int n1, int n2) {
        this.n1 = n1;
        this.n2 = n2;
    }
}