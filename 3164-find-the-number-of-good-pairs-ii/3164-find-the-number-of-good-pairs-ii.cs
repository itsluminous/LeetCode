class Solution {
    public long NumberOfPairs(int[] nums1, int[] nums2, int k) {
        var map = new Dictionary<int, int>();
        foreach(var num in nums2)
            if(!map.ContainsKey(num)) map[num] = 1;
            else map[num]++;

        long good = 0;
        foreach(var num in nums1){
            if(num % k != 0) continue;

            var target = num / k;
            for(var factor = 1; factor * factor <= target; factor++){
                if(target % factor != 0) continue;
                
                if(map.ContainsKey(factor))
                    good += map[factor];
                if(factor != target / factor && map.ContainsKey(target / factor))
                    good += map[target / factor];
            }
        }

        return good;
    }
}