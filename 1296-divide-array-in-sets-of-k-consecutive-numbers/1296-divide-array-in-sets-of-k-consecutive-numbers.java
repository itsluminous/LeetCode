// by sorting
class Solution {
    public boolean isPossibleDivide(int[] nums, int k) {
        if (nums.length % k != 0) return false;

        // count freq of each number
        Arrays.sort(nums);
        var freq = new HashMap<Integer, Integer>();
        for(var num : nums)
            freq.put(num, freq.getOrDefault(num, 0) + 1);
        
        // try to make groups of k
        for(var num : nums) {
            if(freq.get(num) == 0) continue;

            for(var hand = num; hand < num+k; hand++){
                if(!freq.containsKey(hand) || freq.get(hand) == 0) return false;
                freq.put(hand, freq.get(hand) - 1);
            }
        }
        return true;
    }
}

// Accepted - using hashmap
class SolutionHM {
    public boolean isPossibleDivide(int[] nums, int k) {
        var len = nums.length;
        if(len % k != 0) return false;

        // count freq of each number, sorted by key asc
        var freq = new TreeMap<Integer, Integer>();
        for(var num : nums)
            freq.put(num, freq.getOrDefault(num, 0) + 1);

        // try to make groups of k
        while(!freq.isEmpty()){
            var smallest = freq.firstKey();
            for(var hand = smallest; hand < smallest+k; hand++){
                var val = freq.getOrDefault(hand, 0);
                if(val == 0) return false;

                if(val == 1) freq.remove(hand);
                else freq.put(hand, val - 1);
            }
        }
        
        return true;
    }
}