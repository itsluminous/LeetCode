class Solution {
    public int minimumBoxes(int[] apple, int[] capacity) {
        var total = Arrays.stream(apple).sum();
        Arrays.sort(capacity);

        int count = 0, n = capacity.length;
        for(var i=n-1; i>=0 && total > 0; i--){
            count++;
            total -= capacity[i];
        }
        return count;
    }
}