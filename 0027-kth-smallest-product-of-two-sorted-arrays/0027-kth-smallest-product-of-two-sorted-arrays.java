class Solution {
    public long kthSmallestProduct(int[] nums1, int[] nums2, long k) {
        // Step 1 : split nums1 & nums2 into positive and negative numbers list
        List<Integer> n1n = new ArrayList<>(), n1p = new ArrayList<>(); // negative and positive from nums1
        for(var num : nums1){
            if(num < 0) n1n.add(num * -1);
            else n1p.add(num);
        }

        List<Integer> n2n = new ArrayList<>(), n2p = new ArrayList<>(); // negative and positive from nums2
        for(var num : nums2){
            if(num < 0) n2n.add(num * -1);
            else n2p.add(num);
        }

        // Step 2 : Sort the split list (positive will already be sorted, so sort neg only)
        Collections.sort(n1n);
        Collections.sort(n2n);

        // Step 3 : if negative numbers are less than k, we can easily skip all of them
        var negNums = n1n.size() * n2p.size() + n1p.size() * n2n.size();
        var sign = 1;
        if(negNums < k)
            k -= negNums;
        else {
            k = negNums - k + 1;
            sign = -1;
            // swap n2n and n2p so that later we look at negative numbers only
            var temp = n2n;
            n2n = n2p;
            n2p = temp;  
        }


        // Step 4 : Binary search the answer
        long left = 0, right = (long)1e10+1;
        while(left < right){
            var mid = left + (right - left) / 2;
            if(k <= check(n1n, n2n, mid) + check(n1p, n2p, mid))
                right = mid;
            else
                left = mid + 1;
        }

        return sign * left;
    }

    private long check(List<Integer> nums1, List<Integer> nums2, long val){
        long total = 0;
        var j = nums2.size() - 1;

        // move j to left in nums2, till product is more than val
        for(var n1 : nums1){
            while(j >= 0 && (long)n1 * (long)nums2.get(j) > val)
                j--;
            total += j+1;
        }

        return total;
    }
}