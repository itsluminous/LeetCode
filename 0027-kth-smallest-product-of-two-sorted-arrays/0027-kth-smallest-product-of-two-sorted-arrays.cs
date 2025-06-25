public class Solution {
    public long KthSmallestProduct(int[] nums1, int[] nums2, long k) {
        // Step 1 : split nums1 & nums2 into positive and negative numbers list
        List<int> n1n = new(), n1p = new(); // negative and positive from nums1
        foreach(var num in nums1){
            if(num < 0) n1n.Add(num * -1);
            else n1p.Add(num);
        }

        List<int> n2n = new(), n2p = new(); // negative and positive from nums1
        foreach(var num in nums2){
            if(num < 0) n2n.Add(num * -1);
            else n2p.Add(num);
        }

        // Step 2 : Sort the split list (positive will already be sorted, so sort neg only)
        n1n.Sort();
        n2n.Sort();

        // Step 3 : if negative numbers are less than k, we can easily skip all of them
        var negNums = n1n.Count * n2p.Count + n1p.Count * n2n.Count;
        var sign = 1;
        if(negNums < k)
            k -= negNums;
        else {
            k = negNums - k + 1;
            sign = -1;
            (n2n, n2p) = (n2p, n2n);    // swap so that later we look at negative numbers only
        }


        // Step 4 : Binary search the answer
        long left = 0, right = 10_000_000_001;
        while(left < right){
            var mid = left + (right - left) / 2;
            if(k <= Check(n1n, n2n, mid) + Check(n1p, n2p, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return sign * left;
    }

    private long Check(List<int> nums1, List<int> nums2, long val){
        long total = 0;
        var j = nums2.Count - 1;

        // move j to left in nums2, till product is more than val
        foreach(var n1 in nums1){
            while(j >= 0 && (long)n1 * (long)nums2[j] > val)
                j--;
            total += j+1;
        }

        return total;
    }
}