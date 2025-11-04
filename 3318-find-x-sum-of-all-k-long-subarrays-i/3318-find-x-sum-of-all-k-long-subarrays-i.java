class Solution {
    public int[] findXSum(int[] nums, int k, int x) {
        var n = nums.length;
        var answer = new int[n - k + 1];
        Map<Integer, Integer> freq = new HashMap<>();

        // initialize frequency map for the first window
        for(var i = 0; i < k; i++)
            freq.put(nums[i], freq.getOrDefault(nums[i], 0) + 1);

        // calculate x-sum for the first window
        answer[0] = calculateXSum(freq, x);

        // slide the window
        for(var i = 1; i <= n - k; i++) {
            // remove the element going out of the window
            var out = nums[i - 1];
            freq.put(out, freq.get(out) - 1);
            if (freq.get(out) == 0)
                freq.remove(out);

            // add the new element coming into the window
            var in = nums[i + k - 1];
            freq.put(in, freq.getOrDefault(in, 0) + 1);

            // Calculate x-sum for the current window
            answer[i] = calculateXSum(freq, x);
        }

        return answer;
    }

    private int calculateXSum(Map<Integer, Integer> freq, int x) {
        // sort by frequency (descending), then by value (descending)
        List<Map.Entry<Integer, Integer>> sorted = new ArrayList<>(freq.entrySet());
        sorted.sort((a, b) -> {
            if (!b.getValue().equals(a.getValue())) {
                return b.getValue() - a.getValue(); // by frequency descending
            }
            return b.getKey() - a.getKey(); // by value descending
        });

        var sum = 0;
        for(var i = 0; i < Math.min(x, sorted.size()); i++) {
            Map.Entry<Integer, Integer> entry = sorted.get(i);
            sum += entry.getKey() * entry.getValue();
        }

        return sum;
    }
}