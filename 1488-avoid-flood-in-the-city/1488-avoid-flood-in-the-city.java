class Solution {
    public int[] avoidFlood(int[] rains) {
        var n = rains.length;
        var ans = new int[rains.length];

        Map<Integer, Integer> map = new HashMap<>();    // previous appeared idx of rains[i]
        TreeSet<Integer> zeroes = new TreeSet<>();
        
        for(var i=0; i<n; i++){
            if(rains[i] == 0)
                zeroes.add(i);
            else {
                if (map.containsKey(rains[i])) {
                    // find the location of zero that can be used to empty rains[i]
                    Integer next = zeroes.ceiling(map.get(rains[i]));
                    if (next == null) return new int[0];
                    ans[next] = rains[i];
                    zeroes.remove(next);
                }
                ans[i] = -1;
				map.put(rains[i], i);
            }
        }

        for (var i : zeroes) ans[i] = 1;
        return ans;
    }
}