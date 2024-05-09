public class Solution {
    public long MaxScore(int[] nums1, int[] nums2, int k) {
        var n = nums1.Length;
        
        // merge nums1 & nums2 based on index
        var combined = new (int n1, int n2)[n];
        for(var i=0; i<n; i++) combined[i] = (nums1[i], nums2[i]);

        // sort this combined array by nums2 value, descending
        // When we iterate over this sorted array, we know that smallest n2 is curr index
        Array.Sort(combined, (c1, c2) => c2.n2 - c1.n2);

        // priority queue to track smallest in nums1, so that it can be removed if needed
        var pq = new PriorityQueue<int, int>();
        long ans = 0, num1Sum = 0;
        foreach(var cmb in combined){
            num1Sum += cmb.n1;

            pq.Enqueue(cmb.n1, cmb.n1);
            if(pq.Count > k) num1Sum -= pq.Dequeue();   // remove smallest num1
            if(pq.Count == k) ans = Math.Max(ans, num1Sum * cmb.n2);
        }

        return ans;
    }
}