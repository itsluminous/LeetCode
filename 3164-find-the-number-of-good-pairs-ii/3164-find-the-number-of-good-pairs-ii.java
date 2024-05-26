class Solution {
    public long numberOfPairs(int[] nums1, int[] nums2, int k) {
        var map = new HashMap<Integer, Integer>();
        for(var num : nums2)
            map.put(num, map.getOrDefault(num, 0) + 1);

        long good = 0;
        for(var num : nums1){
            if(num % k != 0) continue;

            var target = num / k;
            for(var factor = 1; factor * factor <= target; factor++){
                if(target % factor != 0) continue;
                
                good += map.getOrDefault(factor, 0);
                if(factor != target / factor)
                    good += map.getOrDefault(target / factor, 0);
            }
        }

        return good;
    }
}