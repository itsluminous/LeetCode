class Solution {
    public int findLHS(int[] nums) {
        var freq = new HashMap<Integer, Integer>();
        for(var num : nums)
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        
        var ans = 0;
        for(var num : freq.keySet())
            if(freq.containsKey(num+1))
                ans = Math.max(ans, freq.get(num) + freq.get(num+1));

        return ans;
    }
}