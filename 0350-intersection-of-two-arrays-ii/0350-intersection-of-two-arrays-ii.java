class Solution {
    public int[] intersect(int[] nums1, int[] nums2) {
        var freq = new int[1001];
        for(var num : nums1)
            freq[num]++;
        
        var ans = new ArrayList<Integer>();
        for(var num : nums2){
            if(freq[num] > 0){
                ans.add(num);
                freq[num]--;
            }
        }

        return ans.stream().mapToInt(num -> num).toArray();
    }
}