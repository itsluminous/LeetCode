class Solution {
    public int maxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var n = difficulty.length;
        var difProf = new int[n][2];

        for(var i=0; i<n; i++){
            difProf[i][0] = difficulty[i];
            difProf[i][1] = profit[i];
        }
        Arrays.sort(difProf, (p1, p2) -> p1[0] - p2[0]);   // sort on difficulty

        Arrays.sort(worker);
        int idx = 0, maxProf = 0, ans = 0;
        for(var ability : worker){
            while(idx < n && ability >= difProf[idx][0]){
                maxProf = Math.max(maxProf, difProf[idx][1]);
                idx++;
            }
            ans += maxProf;
        }

        return ans;
    }
}