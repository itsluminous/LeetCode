class Solution {
    public int largestInteger(int[] nums, int k) {
        var MAX = 50;
        var freq = new int[MAX+1];
        
        for(var l = 0; l <= nums.length - k; l++){
            var uniq = new HashSet<Integer>();
            for(var r = l; r < l + k; r++)
                uniq.add(nums[r]);
            
            for(var num : uniq)
                freq[num]++;
        }
                

        for(var i=MAX; i>=0; i--)
            if(freq[i] == 1)
                return i;
        
        return -1;
    }
}