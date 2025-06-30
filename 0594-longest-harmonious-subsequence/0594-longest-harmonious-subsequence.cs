public class Solution {
    public int FindLHS(int[] nums) {
        var freq = new Dictionary<int, int>();
        foreach(var num in nums)
            if(freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        
        var ans = 0;
        foreach(var num in freq.Keys)
            if(freq.ContainsKey(num+1))
                ans = Math.Max(ans, freq[num] + freq[num+1]);

        return ans;
    }
}