public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        var n = s.Length;

        // calculate cost at each index
        var cost = new int[n];
        for(var i=0; i<n; i++)
            cost[i] = Math.Abs(s[i] - t[i]);
        
        // sliding window to find maxCost
        int currCost = 0, count = 0;
        int left = 0, right = 0;
        while(right < n){
            currCost += cost[right];
            while(currCost > maxCost && left <= right){
                currCost -= cost[left++];
            }
            count = Math.Max(count, right-left+1);
            right++;
        }

        return count;
    }
}