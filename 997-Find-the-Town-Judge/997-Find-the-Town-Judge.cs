public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var score = new int[n+1];
        foreach(var t in trust){
            score[t[0]]--;
            score[t[1]]++;
        }
        
        for(var i=1; i<=n; i++)
            if(score[i] == n-1) return i;
            
        return -1;
    }
}