public class Solution {
    public long MaximumHappinessSum(int[] happiness, int k) {
        Array.Sort(happiness);
        long val = 0;

        for(int i=happiness.Length-1, selected = 0; selected < k; i--, selected++){
            var currHappiness = happiness[i] - selected;
            if(currHappiness <= 0) break;
            val += currHappiness;
        }

        return val;
    }
}