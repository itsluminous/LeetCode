public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        var count = new int[26];
        int maxCount = 0, maxNum = 0;
        foreach(var ch in tasks){
            count[ch-'A']++;
            if(count[ch-'A'] > maxCount){
                maxCount = count[ch-'A'];
                maxNum = 1;
            }
            else if(count[ch-'A'] == maxCount){
                maxNum++;
            }
        }

        var ans = (n+1) * (maxCount-1) + maxNum;
        return Math.Max(ans, tasks.Length);
    }
}