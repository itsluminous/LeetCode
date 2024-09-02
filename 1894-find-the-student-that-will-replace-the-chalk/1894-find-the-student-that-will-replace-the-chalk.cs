public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        var usage = chalk.Select(c => (long)c).Sum();
        long kk = k % usage;

        for(var i=0; i<chalk.Length; i++){
            if(chalk[i] > kk) return i;
            kk -= chalk[i];
        }
        return 0;
    }
}