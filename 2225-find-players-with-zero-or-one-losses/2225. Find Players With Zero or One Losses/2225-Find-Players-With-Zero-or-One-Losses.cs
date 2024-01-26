public class Solution {
    public IList<IList<int>> FindWinners(int[][] matches) {
        const int MAX = 100002;
        var played = new bool[MAX];
        var lostCount = new int[MAX];

        foreach(var m in matches){
            played[m[0]] = true;
            played[m[1]] = true;
            lostCount[m[1]]++;
        }

        var nolost = new List<int>();
        var onelost = new List<int>();
        for(var i=0; i<MAX; i++){
            if(played[i] && lostCount[i] == 0) nolost.Add(i);
            if(played[i] && lostCount[i] == 1) onelost.Add(i);
        }

        return new List<IList<int>>{nolost, onelost};
    }
}

// This also passess
public class SolutionHashSet {
    public IList<IList<int>> FindWinners(int[][] matches) {
        HashSet<int> noMatch = new HashSet<int>(), oneMatch = new HashSet<int>(), others = new HashSet<int>();
        
        foreach(var match in matches){
            int winner = match[0], loser = match[1];
            // never lost a match
            if(!others.Contains(winner) && !oneMatch.Contains(winner))
                noMatch.Add(winner);
            
            // already lost more than 1 matches
            if(others.Contains(loser))
                continue;
            // lost one match earlier
            if(oneMatch.Contains(loser)){
                oneMatch.Remove(loser);
                others.Add(loser);
            }
            // never lost earlier, but lost now
            else if(noMatch.Contains(loser)){
                noMatch.Remove(loser);
                oneMatch.Add(loser);
            }
            // playing first game and lost
            else{
                oneMatch.Add(loser);
            }
        }
        
        var result = new List<IList<int>>();
        result.Add(noMatch.OrderBy(p => p).ToList());
        result.Add(oneMatch.OrderBy(p => p).ToList());
        
        return result;
    }
}