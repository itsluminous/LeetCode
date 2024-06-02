public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        var n = nums.Length;
        var zeros = new int[32];        // count how many nums have set bit i to 0
        var ans = int.MaxValue;

        var left = 0;
        for (var right = 0; right < n; right++) {
            AddZeroCount(nums[right], zeros);
            var andVal = CalculateAndVal(zeros);
            ans = Math.Min(ans, Math.Abs(andVal - k));
            while (left < right && andVal < k) {
                RemoveZeroCount(nums[left], zeros);
                andVal = CalculateAndVal(zeros);
                ans = Math.Min(ans, Math.Abs(andVal - k));
                left++;
            }
        }

        return ans;
    }

    void RemoveZeroCount(int x, int[] zeros) {
        for (int i = 0; i < 32; ++i) {
            if (((x >> i) & 1) == 0) {
                zeros[i] -= 1;
            }
        }
    }

    void AddZeroCount(int x, int[] zeros) {
        for (int i = 0; i < 32; ++i) {
            if (((x >> i) & 1) == 0) {
                zeros[i] += 1;
            }
        }
    }

    int CalculateAndVal(int[] zeros) {
        int res = 0;
        for (int i = 0; i < 32; ++i) {
            if (zeros[i] == 0) {
                res ^= (1 << i);
            }
        }
        return res;
    }
}