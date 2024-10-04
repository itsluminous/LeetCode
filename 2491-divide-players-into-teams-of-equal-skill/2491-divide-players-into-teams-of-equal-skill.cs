public class Solution {
    public long DividePlayers(int[] skill) {
        var n = skill.Length;
        int teamCount = n / 2, total = 0;
        var freq = new int[1001];
        foreach(var sk in skill){
            total += sk;
            freq[sk]++;
        }

        if(total % teamCount != 0) return -1;
        var teamSkill = total / teamCount;
        
        long chemistry = 0;
        foreach(var sk in skill){
            var partner = teamSkill - sk;
            if(freq[partner] == 0) return -1;
            chemistry += (sk * partner);
            freq[partner]--;
        }

        return chemistry / 2; // because of double counting of each pair
    }
}