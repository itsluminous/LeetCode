class Solution {
    public int chalkReplacer(int[] chalk, int k) {
        var usage = Arrays.stream(chalk).asLongStream().sum();
        k %= usage;

        for(var i=0; i<chalk.length; i++){
            if(chalk[i] > k) return i;
            k -= chalk[i];
        }
        return 0;
    }
}