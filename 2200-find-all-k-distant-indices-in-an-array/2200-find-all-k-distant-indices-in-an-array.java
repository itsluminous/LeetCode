class Solution {
    public List<Integer> findKDistantIndices(int[] nums, int key, int k) {
        var n = nums.length;
        var keyIndices = new ArrayList<Integer>();
        for(var i=0; i<n; i++)
            if(nums[i] == key)
                keyIndices.add(i);
        
        var ans = new ArrayList<Integer>();
        for(int i=0, ki=0; i<n && ki<keyIndices.size(); i++){
            // if the key is outside k range, look for next key
            if(keyIndices.get(ki) < i && i - keyIndices.get(ki) > k){
                ki++;
                i--;
                continue;
            }
            // if the key is in k range, add curr idx to ans
            if(keyIndices.get(ki) - i <= k)
                ans.add(i);
        }

        return ans;
    }
}