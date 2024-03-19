class Solution {
    public int leastInterval(char[] tasks, int n) {
        var count = new int[26];
        int maxCount = 0, maxNum = 0;
        for(var ch : tasks){
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
        return Math.max(ans, tasks.length);
    }
}