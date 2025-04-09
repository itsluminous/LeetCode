class Solution {
    public int minOperations(int[] nums, int k) {
        var uniq = new HashSet();
        for(var num : nums){
            if(num < k) return -1;              // not possible to convert it to k
            else if(num > k) uniq.add(num);     // all bigger nums need to be converted
        }

        return uniq.size();
    }
}