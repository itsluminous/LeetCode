class Solution {
    public int minimumDifference(int[] nums, int k) {
        var n = nums.length;
        var zeros = new int[32];        // count how many nums have set bit i to 0
        var ans = Integer.MAX_VALUE;

        var left = 0;
        for (var right = 0; right < n; right++) {
            addZeroCount(nums[right], zeros);
            var andVal = calculateAndVal(zeros);
            ans = Math.min(ans, Math.abs(andVal - k));
            while (left < right && andVal < k) {
                removeZeroCount(nums[left], zeros);
                andVal = calculateAndVal(zeros);
                ans = Math.min(ans, Math.abs(andVal - k));
                left++;
            }
        }

        return ans;
    }

    void removeZeroCount(int x, int[] zeros) {
        for (int i = 0; i < 32; ++i) {
            if (((x >> i) & 1) == 0) {
                zeros[i]--;
            }
        }
    }

    void addZeroCount(int x, int[] zeros) {
        for (int i = 0; i < 32; ++i) {
            if (((x >> i) & 1) == 0) {
                zeros[i]++;
            }
        }
    }

    int calculateAndVal(int[] zeros) {
        int res = 0;
        for (int i = 0; i < 32; ++i) {
            if (zeros[i] == 0) {
                res |= (1 << i);
            }
        }
        return res;
    }
}