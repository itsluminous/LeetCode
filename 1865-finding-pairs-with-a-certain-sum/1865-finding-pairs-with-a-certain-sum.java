class FindSumPairs {
    int[] nums2;
    Map<Integer, Integer> freq1, freq2;

    public FindSumPairs(int[] nums1, int[] nums2) {
        Arrays.sort(nums1);
        freq1 = new LinkedHashMap<>();  // to maintain sorted order
        for(var num : nums1)
            freq1.put(num, freq1.getOrDefault(num, 0) + 1);
        
        this.nums2 = nums2;
        freq2 = new HashMap<>();
        for(var num : nums2)
            freq2.put(num, freq2.getOrDefault(num, 0) + 1);
    }
    
    public void add(int index, int val) {
        var num = nums2[index];
        if(freq2.get(num) == 1) freq2.remove(num);
        else freq2.put(num, freq2.get(num) - 1);

        num += val;
        nums2[index] += val;
        freq2.put(num, freq2.getOrDefault(num, 0) + 1);
    }
    
    public int count(int tot) {
        var ans = 0;
        for(var num : freq1.keySet()){
            if(num >= tot) break;   // can't find match beyond this
            if(!freq2.containsKey(tot - num)) continue;
            ans += freq1.get(num) * freq2.get(tot-num);
        }
        return ans;
    }
}

/**
 * Your FindSumPairs object will be instantiated and called as such:
 * FindSumPairs obj = new FindSumPairs(nums1, nums2);
 * obj.add(index,val);
 * int param_2 = obj.count(tot);
 */