class Solution {
    public int matchPlayersAndTrainers(int[] players, int[] trainers) {
        Arrays.sort(players);
        Arrays.sort(trainers);

        int ans = 0, t = 0;
        for(var p : players){
            while(t < trainers.length && trainers[t] < p) t++;
            if(t == trainers.length) break;
            ans++;
            t++;
        }
        return ans;
    }
}