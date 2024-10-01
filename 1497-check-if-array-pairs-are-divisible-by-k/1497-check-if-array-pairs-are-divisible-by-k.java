class Solution {
    public boolean canArrange(int[] arr, int k) {
        var freq = new int[k];
        for(var num : arr){
            int mod = num % k;
            if(mod < 0) mod += k;
            var remaining = mod == 0 ? 0 : k - mod;

            if(freq[remaining] > 0) freq[remaining]--;
            else freq[mod]++;
        }

        return Arrays.stream(freq).sum() == 0;
    }
}