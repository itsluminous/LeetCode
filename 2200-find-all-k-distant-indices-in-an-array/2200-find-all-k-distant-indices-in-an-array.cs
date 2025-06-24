public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        var n = nums.Length;
        var keyIndices = new List<int>();
        for(var i=0; i<n; i++)
            if(nums[i] == key)
                keyIndices.Add(i);
        
        var ans = new List<int>();
        for(int i=0, ki=0; i<n && ki<keyIndices.Count; i++){
            // if the key is outside k range, look for next key
            if(keyIndices[ki] < i && i - keyIndices[ki] > k){
                ki++;
                i--;
                continue;
            }
            // if the key is in k range, add curr idx to ans
            if(keyIndices[ki] - i <= k)
                ans.Add(i);
        }

        return ans;
    }
}