public class Solution {
    public int LargestInteger(int[] nums, int k) {
        var MAX = 50;
        var freq = new int[MAX+1];
        
        for(var l = 0; l <= nums.Length - k; l++){
            var uniq = new HashSet<int>();
            for(var r = l; r < l + k; r++)
                uniq.Add(nums[r]);
            
            foreach(var num in uniq)
                freq[num]++;
        }
                

        for(var i=MAX; i>=0; i--)
            if(freq[i] == 1)
                return i;
        
        return -1;
    }
}