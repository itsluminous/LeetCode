public class Solution {
    public bool CanArrange(int[] arr, int k) {
        var freq = new int[k];
        foreach(var num in arr){
            int mod = num % k;
            if(mod < 0) mod += k;
            var remaining = mod == 0 ? 0 : k - mod;

            if(freq[remaining] > 0) freq[remaining]--;
            else freq[mod]++;
        }

        return freq.Sum() == 0;
    }
}