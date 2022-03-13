public class Solution {
    public IList<int> FindKDistantIndices(int[] nums, int key, int k) {
        var n = nums.Length;
        var keyIdx = new List<int>();
        
        // find all indexes of key
        for(var i=0; i<n; i++){
            if(nums[i] == key) keyIdx.Add(i);
        }
        
        // fins all K-Distant indices
        var result = new List<int>();
        for(int i=0, jIdx=0; i<n; i++){
            var j = keyIdx[jIdx]; 
            if(Math.Abs(i-j) <= k)
                result.Add(i);
            else if(jIdx < keyIdx.Count - 1 && Math.Abs(i-keyIdx[jIdx+1]) <= k){
                result.Add(i);
            }
            
            if(i-j >= k && jIdx < keyIdx.Count - 1)
                jIdx++;
        }
        
        return result;
    }
}