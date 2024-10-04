class Solution {
    public long dividePlayers(int[] skill) {
        var n = skill.length;
        int teamCount = n / 2, total = 0;
        var freq = new int[1001];
        for(var sk : skill){
            total += sk;
            freq[sk]++;
        }

        if(total % teamCount != 0) return -1;
        var teamSkill = total / teamCount;
        
        long chemistry = 0;
        for(var sk : skill){
            var partner = teamSkill - sk;
            if(freq[partner] == 0) return -1;
            chemistry += (sk * partner);
            freq[partner]--;
        }

        return chemistry / 2; // because of double counting of each pair
    }
}