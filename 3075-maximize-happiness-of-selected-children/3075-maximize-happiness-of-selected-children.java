class Solution {
    public long maximumHappinessSum(int[] happiness, int k) {
        Arrays.sort(happiness);
        long val = 0;

        for(int i=happiness.length-1, selected = 0; selected < k; i--, selected++){
            var currHappiness = happiness[i] - selected;
            if(currHappiness <= 0) break;
            val += currHappiness;
        }

        return val;
    }
}