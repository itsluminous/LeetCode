class Solution {
    public long minCost(int[] basket1, int[] basket2) {
        var freq = new HashMap<Integer, Integer>();
        var minVal = Integer.MAX_VALUE;

        // increase freq count for basket1
        for(var b : basket1){
            freq.put(b, freq.getOrDefault(b, 0) + 1);
            minVal = Math.min(minVal, b);
        }
        // decrease freq count for basket2
        for(var b : basket2){
            freq.put(b, freq.getOrDefault(b, 0) - 1);
            minVal = Math.min(minVal, b);
        }

        // find out elements that need swapping
        var swp = new ArrayList<Integer>();
        for(var k : freq.keySet()){
            var count = freq.get(k);
            if((count & 1) == 1) return -1; // impossible to match odd count

            // the elements left in freq map need to be swapped
            count = Math.abs(count);
            for(var i=0; i < count/2; i++)
                swp.add(k);
        }

        // we ideally will swap all big elements with all small elements
        // but sometimes it is cheaper to swap minVal to and fro in both arrays with element1 and element2
        Collections.sort(swp);
        long ans = 0;
        for(var i=0; i<swp.size()/2; i++)
            ans += Math.min(swp.get(i), minVal * 2);
        
        return ans;
    }
}