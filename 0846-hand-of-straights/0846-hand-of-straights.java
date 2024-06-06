// by sorting
class Solution {
    public boolean isNStraightHand(int[] hand, int groupSize) {
        if (hand.length % groupSize != 0) return false;

        // count freq of each number
        Arrays.sort(hand);
        var freq = new HashMap<Integer, Integer>();
        for(var num : hand)
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        
        // try to make groups of groupSize
        for(var num : hand) {
            if(freq.get(num) == 0) continue;

            for(var nmbr = num; nmbr < num+groupSize; nmbr++){
                if(!freq.containsKey(nmbr) || freq.get(nmbr) == 0) return false;
                freq.put(nmbr, freq.get(nmbr) - 1);
            }
        }
        return true;
    }
}

// Accepted - using hashmap
class SolutionHM {
    public boolean isNStraightHand(int[] hand, int groupSize) {
        var len = hand.length;
        if(len % groupSize != 0) return false;

        // count freq of each number, sorted by groupSizeey asc
        var freq = new TreeMap<Integer, Integer>();
        for(var num : hand)
            freq.put(num, freq.getOrDefault(num, 0) + 1);

        // try to make groups of groupSize
        while(!freq.isEmpty()){
            var smallest = freq.firstKey();
            for(var nmbr = smallest; nmbr < smallest+groupSize; nmbr++){
                var val = freq.getOrDefault(nmbr, 0);
                if(val == 0) return false;

                if(val == 1) freq.remove(nmbr);
                else freq.put(nmbr, val - 1);
            }
        }
        
        return true;
    }
}