public class Solution {
    public int[] FindXSum(int[] nums, int k, int x) {
        var n = nums.Length;
        var answer = new int[n - k + 1];
        var freq = new Dictionary<int, int>();

        // initialize frequency map for the first window
        for(var i = 0; i < k; i++){
            if (!freq.ContainsKey(nums[i]))
                freq[nums[i]] = 0;
            freq[nums[i]]++;
        }

        // calculate x-sum for the first window
        answer[0] = CalculateXSum(freq, x);

        // slide the window
        for(var i = 1; i <= n - k; i++)
        {
            // remove the element going out of the window
            freq[nums[i - 1]]--;
            if(freq[nums[i - 1]] == 0)
                freq.Remove(nums[i - 1]);

            // add the new element coming into the window
            if(!freq.ContainsKey(nums[i + k - 1]))
                freq[nums[i + k - 1]] = 0;
            freq[nums[i + k - 1]]++;

            // calculate x-sum for the current window
            answer[i] = CalculateXSum(freq, x);
        }

        return answer;
    }

    private int CalculateXSum(Dictionary<int, int> freq, int x){
        // sort by frequency (descending), then by value (descending)
        var sorted = freq
            .OrderByDescending(entry => entry.Value)
            .ThenByDescending(entry => entry.Key)
            .Take(x);

        int sum = 0;
        foreach(var entry in sorted)
            sum += entry.Key * entry.Value;

        return sum;
    }
}