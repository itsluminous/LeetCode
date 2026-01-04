public class Solution {
    public int MinimumBoxes(int[] apple, int[] capacity) {
        var total = apple.Sum();
        Array.Sort(capacity);

        int count = 0, n = capacity.Length;
        for(var i=n-1; i>=0 && total > 0; i--){
            count++;
            total -= capacity[i];
        }
        
        return count;
    }
}