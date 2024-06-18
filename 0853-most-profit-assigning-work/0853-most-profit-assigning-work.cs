public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var n = difficulty.Length;
        var difProf = new (int dif, int prof)[n];

        for(var i=0; i<n; i++)
            difProf[i] = (difficulty[i], profit[i]);
        Array.Sort(difProf, (p1, p2) => p1.dif - p2.dif);   // sort on difficulty

        Array.Sort(worker);
        int idx = 0, maxProf = 0, ans = 0;
        foreach(var ability in worker){
            while(idx < n && ability >= difProf[idx].dif){
                maxProf = Math.Max(maxProf, difProf[idx].prof);
                idx++;
            }
            ans += maxProf;
        }

        return ans;
    }
}