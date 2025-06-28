public class Solution {
    public int[] MaxSubsequence(int[] nums, int k) {
        var n = nums.Length;
        var clone = (int[])nums.Clone();
        Array.Sort(clone);
        
        // find the starting point in sorted clone array
        var mid = clone[n-k];
        var midCount = 0;
        for(var i=n-k; i<n && clone[i] == mid; i++) midCount++;

        var ans = new int[k];
        var idx = 0;    // idx in ans array
        foreach(var num in nums){
            if(num > mid)
                ans[idx++] = num;
            else if(num == mid && midCount > 0){
                ans[idx++] = num;
                midCount--;
            }

            if(idx == k) break; // found k digits
        }

        return ans;
    }
}