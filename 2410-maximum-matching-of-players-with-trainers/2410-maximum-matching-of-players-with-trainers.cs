public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        Array.Sort(players);
        Array.Sort(trainers);

        int ans = 0, t = 0;
        foreach(var p in players){
            while(t < trainers.Length && trainers[t] < p) t++;
            if(t == trainers.Length) break;
            ans++;
            t++;
        }
        return ans;
    }
}